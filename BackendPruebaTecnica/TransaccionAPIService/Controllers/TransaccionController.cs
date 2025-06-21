using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TransaccionAPIService.Data;
using TransaccionAPIService.Models;
using TransaccionAPIService.Services;

namespace TransaccionAPIService.Controllers
{
    [ApiController]
    [Route("api/transacciones")]
    public class TransaccionController : ControllerBase
    {
        private readonly TransaccionDbContext _context;
        private readonly ProductoApiClient _productoApi;

        public TransaccionController(TransaccionDbContext context, ProductoApiClient productoApi)
        {
            _context = context;
            _productoApi = productoApi;
        }

        [HttpGet]
        public IActionResult Get(
            [FromQuery] int? productoId,
            [FromQuery] string? tipo,
            [FromQuery] DateTime? fechaDesde,
            [FromQuery] DateTime? fechaHasta)
        {
            var query = _context.Transacciones.AsQueryable();

            if (productoId.HasValue)
                query = query.Where(t => t.ProductoId == productoId.Value);

            if (!string.IsNullOrEmpty(tipo))
                query = query.Where(t => t.TipoTransaccion.ToLower() == tipo.ToLower());

            if (fechaDesde.HasValue)
                query = query.Where(t => t.FechaTransaccion >= fechaDesde.Value);

            if (fechaHasta.HasValue)
                query = query.Where(t => t.FechaTransaccion <= fechaHasta.Value);

            var result = query
                .OrderByDescending(t => t.FechaTransaccion)
                .ToList();

            return Ok(result);
        }


        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var transaccion = _context.Transacciones.FirstOrDefault(t => t.TransaccionId == id);
            return transaccion == null ? NotFound() : Ok(transaccion);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Transaccion transaccion)
        {
            var producto = await _productoApi.ObtenerProducto(transaccion.ProductoId);
            if (producto == null)
                return NotFound("Producto no encontrado.");

            if (transaccion.TipoTransaccion.ToLower() == "venta" &&
                producto.StockProducto < transaccion.CantidadTransaccion)
                return BadRequest("Stock insuficiente.");

            transaccion.FechaTransaccion = DateTime.UtcNow;

            _context.Transacciones.Add(transaccion);
            await _context.SaveChangesAsync();

            if (transaccion.TipoTransaccion.ToLower() == "venta")
                await _productoApi.AjustarStock(transaccion.ProductoId, transaccion.CantidadTransaccion);

            return CreatedAtAction(nameof(GetById), new { id = transaccion.TransaccionId }, transaccion);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Transaccion input)
        {
            var transaccion = await _context.Transacciones.FindAsync(id);
            if (transaccion == null)
                return NotFound();

            transaccion.TipoTransaccion = input.TipoTransaccion;
            transaccion.ProductoId = input.ProductoId;
            transaccion.CantidadTransaccion = input.CantidadTransaccion;
            transaccion.PrecioUnitarioTransaccion = input.PrecioUnitarioTransaccion;
            transaccion.DetalleTransaccion = input.DetalleTransaccion;

            await _context.SaveChangesAsync();
            return Ok(transaccion);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var transaccion = await _context.Transacciones.FindAsync(id);
            if (transaccion == null)
                return NotFound();

            _context.Transacciones.Remove(transaccion);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
