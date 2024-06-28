using Microservices.Web.DTOs.Product;

namespace Microservices.Web.Services
{
    public interface IProductService
    {
        Task<List<ProductDTO>> GetAll();

        Task<ProductDTO> GetById(int id);
    }
}
