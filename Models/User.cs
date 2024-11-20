using System.ComponentModel.DataAnnotations;

namespace NexCart.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        [Required, MaxLength(100)]
        public string Name { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }

        [Required]
        public string PasswordHash { get; set; }

        public string Address { get; set; }
        public string ContactNumber { get; set; }
        //navigations 
        public ICollection<Order> Orders { get; set; }
    }
}
