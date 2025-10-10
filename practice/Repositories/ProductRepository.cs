using Microsoft.EntityFrameworkCore;
using practice.Data;
using practice.Models;

namespace practice.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _appDbContext;
        public ProductRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<IEnumerable<Product>> GetAllAsync() => await _appDbContext.products.ToListAsync();

        public async Task<Product?> GetByIdAsync(int id) => await _appDbContext.products.FindAsync(id);

        public async Task AddAsync(Product product)
        {
            _appDbContext.products.Add(product);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(Product product)
        {
            _appDbContext.products.Update(product);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var product = await _appDbContext.products.FindAsync(id);
            if (product != null)
            {
                _appDbContext.products.Remove(product);
                await _appDbContext.SaveChangesAsync();
            }

        }
    }
}
