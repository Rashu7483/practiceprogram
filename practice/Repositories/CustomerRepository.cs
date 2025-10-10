using Microsoft.EntityFrameworkCore;
using practice.Data;
using practice.Models;

namespace practice.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly AppDbContext _appDbContext;
        public CustomerRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        // For displaying all customers in Swagger with minimal fields
        public async Task<List<Customer>> GetAllAsync()
        {
            return await _appDbContext.customers
                .Include(c => c.Orders)   
                .ToListAsync();
        }

        // For getting details of a specific customer, include related Orders
        public async Task<Customer?> GetByIdAsync(int id) =>
            await _appDbContext.customers
                .Include(c => c.Orders)
                .FirstOrDefaultAsync(c => c.CustomerId == id);

        // For insert, you need full entity
        public async Task AddAsync(Customer customer)
        {
            _appDbContext.customers.Add(customer);
            await _appDbContext.SaveChangesAsync();
        }

        // For update, you can attach only fields you want to update
        public async Task UpdateAsync(Customer customer)
        {
            var existingCustomer = await _appDbContext.customers.FindAsync(customer.CustomerId);

            if (existingCustomer != null)
            {
                // Update only specific fields
                existingCustomer.FirstName = customer.FirstName;
                existingCustomer.Email = customer.Email;
                // if Orders should not be touched, skip them
                await _appDbContext.SaveChangesAsync();
            }
        }

        // For delete, only need ID
        public async Task DeleteAsync(int id)
        {
            var customer = await _appDbContext.customers.FindAsync(id);
            if (customer != null)
            {
                _appDbContext.customers.Remove(customer);
                await _appDbContext.SaveChangesAsync();
            }
        }
    }
}
