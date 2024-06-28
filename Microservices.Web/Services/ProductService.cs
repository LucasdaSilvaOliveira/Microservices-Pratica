using Microservices.Web.DTOs.Product;
using System.Text.Json;

namespace Microservices.Web.Services
{
    public class ProductService : IProductService
    {
        private readonly HttpClient _httpClient;
        const string BasePath = "api/Product";
        public ProductService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<ProductDTO>> GetAll()
        {
            var response = await _httpClient.GetAsync(BasePath);

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync().ConfigureAwait(true);

                var products = JsonSerializer.Deserialize<List<ProductDTO>>(content, options);

                return products;
            }
            throw new Exception("Erro ao buscar os dados no serviço.");
        }

        public Task<ProductDTO> GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
