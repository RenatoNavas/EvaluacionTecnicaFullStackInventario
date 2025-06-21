namespace TransaccionAPIService.Models
{
    public class ProductoDto
    {
        public int ProductoId { get; set; }
        public string NombreProducto { get; set; } = null!;
        public int StockProducto { get; set; }
    }
}
