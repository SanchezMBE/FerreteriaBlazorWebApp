using Ferreteria.Data;
using Ferreteria.Models;
using Microsoft.EntityFrameworkCore;

namespace Ferreteria.Repositories
{
    public class RepositoryProducts : IRepositoryProducts
    {
        private readonly FerreteriaDbContext _context;
        public RepositoryProducts(FerreteriaDbContext context)
        {
            _context = context;
        }
        public async Task<Product> Add(Product product)
        {
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
            return product;
        }

        public async Task Delete(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product != null)
            {
                _context.Products.Remove(product);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<Product?> Get(int id)
        {
            return await _context.Products.FindAsync(id);
        }

        public async Task<List<Product>> GetAll()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task Update(int id, Product product)
        {
            var currentProduct = await _context.Products.FindAsync(id);
            if (currentProduct != null)
            {
                currentProduct.Code = product.Code;
                currentProduct.Description = product.Description;
                currentProduct.BuyPrice = product.BuyPrice;
                currentProduct.SalePrice = product.SalePrice;
                currentProduct.StockQuantity = product.StockQuantity;
                await _context.SaveChangesAsync();
            }
        }
    }

}
