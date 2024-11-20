using System.ComponentModel.DataAnnotations;

namespace NexCart.Models
{
    public class Seller
    {
        [Key]
        public int SellerId { get; set; }

        [Required, MaxLength(100)]
        public string Name { get; set; }

        public string ContactNumber { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}
