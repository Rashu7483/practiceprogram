using System.ComponentModel.DataAnnotations;

namespace practice.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        [Range(1, double.MaxValue)]
        public decimal Price { get; set; }

        public string description { get; set; } = string.Empty ;

    }
}
