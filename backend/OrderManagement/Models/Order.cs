using System.ComponentModel.DataAnnotations;

namespace OrderManagement.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int CustomerId { get; set; } // Främmande nyckel

        public Customer? Customer { get; set; } // Navigeringsegenskap

        [Required]
        public List<Product> Products { get; set; } = new List<Product>();

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? ShippedAt { get; set; }

        public decimal TotalCost => Products.Sum(p => p.Price * p.Quantity);
    }
}