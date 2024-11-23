using System.ComponentModel.DataAnnotations;

namespace NexCart.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        [Required, MaxLength(100)]
        public string? FirstName { get; set; }

        [Required, MaxLength(100)]
        public string? LastName { get; set; }

        [Required, EmailAddress]
        public string? Email { get; set; }

        [Required]
        public string? PasswordHash { get; set; }
        [Required]
        public string? ContactNumber { get; set; }

        public bool IsActive { get; internal set; } = true;

        //navigations 
        public ICollection<Order>? Orders { get; set; }
        public Address? address { get; set; }
    
    }
}
