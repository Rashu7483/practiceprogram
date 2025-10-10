using Microsoft.EntityFrameworkCore;
using practice.Models;

namespace practice.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<Product> products { get; set; }

        public DbSet<Customer> customers { get; set; }
        public DbSet<Order> orders { get; set; }
    }
}
