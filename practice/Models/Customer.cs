using Microsoft.EntityFrameworkCore.Metadata.Internal;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace practice.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }            // Primary Key
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string? Address { get; set; }

        // Navigation property(One-to-Many): It means one Customer can have many Orders.
        public List<Order> Orders { get; set; } = new();
    }
}
