using Microservices.ProductAPI.Data;
using Microservices.ProductAPI.ValueObject;

namespace Microservices.ProductAPI.Repositories
{
    public interface IProductRepository
    {
        Task<List<ProductVO>> GetAll();
        Task<ProductVO> GetById(int id);
        Task<ProductVO> Add(ProductVO product);
        void Update(ProductVO product);
        void Remove(ProductVO product);
    }
}
