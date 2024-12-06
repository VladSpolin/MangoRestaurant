using AutoMapper;
using Mango.Sevices.ProductAPI.DbContexts;
using Mango.Sevices.ProductAPI.Models;
using Mango.Sevices.ProductAPI.Models.Dtos;
using Microsoft.EntityFrameworkCore;

namespace Mango.Sevices.ProductAPI.Repository.Implementations
{
    public class ProductRepository : IProductRepository
    {

        private readonly ApplicationDbContext _db;
        private IMapper _mapper;

        public ProductRepository(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }


        public async Task<ProductDto> CreateUpdateProduct(ProductDto productDto)
        {
            var product = _mapper.Map<Product>(productDto);
            if (product.ProductId>0) _db.Products.Update(product);
            else _db.Products.Add(product);
            await _db.SaveChangesAsync();
            return _mapper.Map<ProductDto>(product);
        }

        public async Task<bool> DeleteProduct(int productId)
        {
            try
            {
                var product = await _db.Products.FirstOrDefaultAsync(x => x.ProductId == productId);
                if (product == null) return false;
                _db.Products.Remove(product);
                await _db.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public async Task<ProductDto> GetProductById(int productId)
        {
            var product = await _db.Products.FirstOrDefaultAsync(x => x.ProductId == productId);
            return _mapper.Map<ProductDto>(product);
        }

        public async Task<IEnumerable<ProductDto>> GetProducts()
        {
            List<Product> productList = await _db.Products.ToListAsync();
            return _mapper.Map<List<ProductDto>>(productList);
        }
    }
}
