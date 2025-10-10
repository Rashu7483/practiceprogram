using practice.Models;

namespace practice.Repositories
{
    public interface IProductRepository
    {
        public Task<IEnumerable<Product>> GetAllAsync();

        public Task<Product> GetByIdAsync(int id);
        public Task AddAsync(Product product);
        public Task UpdateAsync(Product product);
        public Task DeleteAsync(int id);

    }
}
