using System.ComponentModel.DataAnnotations;

namespace TransaccionAPIService.Models
{
    public class Transaccion
    {
        [Key]
        public int TransaccionId { get; set; }

        [Required]
        public DateTime FechaTransaccion { get; set; }

        [Required]
        public string TipoTransaccion { get; set; } = null!;

        [Required]
        public int ProductoId { get; set; }

        [Required]
        public int CantidadTransaccion { get; set; }

        [Required]
        public decimal PrecioUnitarioTransaccion { get; set; }

        public decimal PrecioTotalTransaccion => CantidadTransaccion * PrecioUnitarioTransaccion;

        public string? DetalleTransaccion { get; set; }
    }
}
