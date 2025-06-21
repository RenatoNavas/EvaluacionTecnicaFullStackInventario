using System.ComponentModel.DataAnnotations;

namespace ProductoAPIService.Models
{
    public class Producto
    {
        [Key]
        public int ProductoId { get; set; }

        [Required]
        public string NombreProducto { get; set; }

        public string? DescripcionProducto { get; set; }
        
        public string? CategoriaProducto { get; set; }

        public string? ImagenProducto { get; set; }

        [Required]
        public decimal PrecioProducto { get; set; }

        [Required]
        public int StockProducto { get; set; }
    }
}
