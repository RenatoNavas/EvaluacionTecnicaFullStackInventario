using Microsoft.AspNetCore.Mvc;
using ProductoAPIService.Data;
using ProductoAPIService.Models;

namespace ProductoAPIService.Controllers
{
    [ApiController]
    [Route("api/productos")]
    public class ProductoController : ControllerBase
    {
        private readonly ProductoDbContext _context;

        public ProductoController(ProductoDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var productos = _context.Productos.ToList();
            return Ok(productos);
        }

        [HttpGet("{id:int}")]
        public IActionResult GetById(int id)
        {
            var producto = _context.Productos.FirstOrDefault(p => p.ProductoId == id);
            return producto == null ? NotFound() : Ok(producto);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Producto producto)
        {
            _context.Productos.Add(producto);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetById), new { id = producto.ProductoId }, producto);
        }

        [HttpPut("{id:int}")]
        public IActionResult Update(int id, [FromBody] Producto input)
        {
            var producto = _context.Productos.FirstOrDefault(p => p.ProductoId == id);
            if (producto == null) return NotFound();

            producto.NombreProducto = input.NombreProducto;
            producto.DescripcionProducto = input.DescripcionProducto;
            producto.CategoriaProducto = input.CategoriaProducto;
            producto.ImagenProducto = input.ImagenProducto;
            producto.PrecioProducto = input.PrecioProducto;
            producto.StockProducto = input.StockProducto;

            _context.SaveChanges();
            return Ok(producto);
        }

        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            var producto = _context.Productos.FirstOrDefault(p => p.ProductoId == id);
            if (producto == null) return NotFound();

            _context.Productos.Remove(producto);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpPut("{id:int}/ajustar-stock")]
        public IActionResult AjustarStock(int id, [FromBody] int cantidad)
        {
            var producto = _context.Productos.FirstOrDefault(p => p.ProductoId == id);
            if (producto == null) return NotFound();

            if (producto.StockProducto < cantidad)
                return BadRequest("Stock insuficiente.");

            producto.StockProducto -= cantidad;
            _context.SaveChanges();
            return Ok();
        }
    }
}
