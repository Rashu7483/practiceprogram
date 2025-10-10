namespace practice.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalAmount { get; set; }

        // Foreign key
        public int CustomerId { get; set; }
        // Navigation property (Many-to-One) : It means many Orders belong to one Customer
        public Customer Customer { get; set; } = new();
    }

}
