using Microservices.ProductAPI.Data;
using Microservices.ProductAPI.Data.Context;
using Microservices.ProductAPI.ValueObject;
using Microsoft.EntityFrameworkCore;

namespace Microservices.ProductAPI.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly BancoContext _context;
        public ProductRepository(BancoContext context)
        {
            _context = context;
        }
        public async Task<ProductVO> Add(ProductVO productVO)
        {
            var product = new Product
            {
                Id = productVO.Id,
                Name = productVO.Name,
                Price = productVO.Price
            };
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
            return productVO;
        }

        public async Task<List<ProductVO>> GetAll()
        {
            var productVO = await _context.Products.Select(x => new ProductVO
            {
                Id = x.Id,
                Name = x.Name,
                Price = x.Price
            }).ToListAsync();

            return productVO;
        }

        public async Task<ProductVO> GetById(int id)
        {
            if (id == 0) throw new ArgumentException("Houve um problema na solicitação do produto. Id igual a zero");

            var product = await _context.Products.FirstOrDefaultAsync(x => x.Id == id);

            var productVO = new ProductVO
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price
            };

            return productVO;
        }

        public async void Remove(ProductVO productVO)
        {
            var product = new Product
            {
                Id= productVO.Id,
                Name = productVO.Name,
                Price = productVO.Price
            };

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
        }

        public async void Update(ProductVO productVO)
        {
            var product = new Product
            {
                Id = productVO.Id,
                Name = productVO.Name,
                Price = productVO.Price
            };
            _context.Products.Update(product);
            await _context.SaveChangesAsync();
        }
    }
}
