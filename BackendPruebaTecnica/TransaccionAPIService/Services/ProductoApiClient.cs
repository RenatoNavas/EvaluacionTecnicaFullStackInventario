using TransaccionAPIService.Models;

namespace TransaccionAPIService.Services
{
    public class ProductoApiClient
    {
        private readonly HttpClient _httpClient;
        private const string BASE_URL = "https://localhost:7256/api/productos"; 
        public ProductoApiClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<ProductoDto?> ObtenerProducto(int productoId)
        {
            var response = await _httpClient.GetAsync($"{BASE_URL}/{productoId}");
            return response.IsSuccessStatusCode
                ? await response.Content.ReadFromJsonAsync<ProductoDto>()
                : null;
        }

        public async Task<bool> AjustarStock(int productoId, int cantidad)
        {
            var response = await _httpClient.PutAsJsonAsync($"{BASE_URL}/{productoId}/ajustar-stock", cantidad);
            return response.IsSuccessStatusCode;
        }
    }
}
