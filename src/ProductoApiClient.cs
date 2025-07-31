using ApiTransacciones.Models;
using System.Text.Json;

namespace ApiTransacciones.Data
{
    public class ProductoApiClient
    {
        private readonly HttpClient _http;
        private readonly IConfiguration _config;

        public ProductoApiClient(HttpClient http, IConfiguration config)
        {
            _http = http;
            _config = config;
            _http.BaseAddress = new Uri(_config["ProductosApiUrl"]!);
        }

        public async Task<ProductoDto?> ObtenerProducto(int id)
        {
            try
            {
                //var resp = await _http.GetAsync("/api/Productos");      
                var response = await _http.GetAsync($"/api/Productos/{id}");
                if (!response.IsSuccessStatusCode)
                    return null;

                var json = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<ProductoDto>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener producto: {ex.Message}");
                Console.WriteLine($"/api/Productos/{id}");
                return null;
            }
        }
    }
}
