using System.ComponentModel.DataAnnotations;

namespace OrderManagement.Models
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public required string Name { get; set; }

        [Required]
        [EmailAddress]
        public required string Email { get; set; }

        [Required]
        public required string Address { get; set; }

        [Required]
        public required string ZipCode { get; set; }

        [Required]
        public required string Country { get; set; }
    }
}