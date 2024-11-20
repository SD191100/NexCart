using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace NexCart.Models
{
    //public class ProductInventory
    //{
    //    [Key]
    //    public int InventoryId { get; set; }

    //    [Required]
    //    public int ProductId { get; set; }

    //    [ForeignKey("ProductId")]
    //    public Product Product { get; set; }

    //    [Required]
    //    public int StockAvailable { get; set; }

    //    [Required]
    //    public int StockReserved { get; set; }

    //    [Required]
    //    public DateTime LastUpdated { get; set; }
    //}

    //public class User
    //{
    //    [Key]
    //    public int UserId { get; set; }

    //    [Required, MaxLength(100)]
    //    public string Name { get; set; }

    //    [Required, EmailAddress]
    //    public string Email { get; set; }

    //    [Required]
    //    public string PasswordHash { get; set; }

    //    public string Address { get; set; }
    //    public string ContactNumber { get; set; }
    //    //navigations 
    //    public ICollection<Order> Orders { get; set; }
    //}

    //public class Product
    //{
    //    [Key]
    //    public int ProductId { get; set; }

    //    [Required, MaxLength(200)]
    //    public string Name { get; set; }

    //    [Required]
    //    public int CategoryId { get; set; }

    //    [ForeignKey("CategoryId")]
    //    public Category Category { get; set; }

    //    [Required]
    //    public decimal Price { get; set; }

    //    public int StockNumber { get; set; }

    //    public string Description { get; set; }

    //    public ProductInventory Inventory { get; set; }
    //}

    //public class Order
    //{
    //    [Key]
    //    public int OrderId { get; set; }

    //    [Required]
    //    public int UserId { get; set; }

    //    [ForeignKey("UserId")]
    //    public User User { get; set; }

    //    public DateTime OrderDate { get; set; }

    //    public ICollection<OrderDetail> OrderDetails { get; set; }
    //    public ICollection<Payment> Payments { get; set; }
    //}

    //public class OrderDetail
    //{
    //    [Key]
    //    public int OrderDetailId { get; set; }

    //    [Required]
    //    public int OrderId { get; set; }

    //    [ForeignKey("OrderId")]
    //    public Order Order { get; set; }

    //    [Required]
    //    public int ProductId { get; set; }

    //    [ForeignKey("ProductId")]
    //    public Product Product { get; set; }

    //    public int Quantity { get; set; }

    //    public decimal Price { get; set; }
    //}

    //public class Seller
    //{
    //    [Key]
    //    public int SellerId { get; set; }

    //    [Required, MaxLength(100)]
    //    public string Name { get; set; }

    //    public string ContactNumber { get; set; }

    //    public ICollection<Product> Products { get; set; }
    //}

    //public class Cart
    //{
    //    [Key]
    //    public int CartId { get; set; }

    //    [Required]
    //    public int UserId { get; set; }

    //    [ForeignKey("UserId")]
    //    public User User { get; set; }

    //    public ICollection<CartItem> CartItems { get; set; }
    //}

    //public class CartItem
    //    {
    //        [Key]
    //        public int CartItemId { get; set; }

    //        [Required]
    //        public int CartId { get; set; }

    //        [ForeignKey("CartId")]
    //        public Cart Cart { get; set; }

    //        [Required]
    //        public int ProductId { get; set; }

    //        [ForeignKey("ProductId")]
    //        public Product Product { get; set; }

    //        public int Quantity { get; set; }
    //    }

    //public class Payment
    //{
    //    [Key]
    //    public int PaymentId { get; set; }

    //    [Required]
    //    public int OrderId { get; set; }

    //    [ForeignKey("OrderId")]
    //    public Order Order { get; set; }

    //    [Required]
    //    public decimal Amount { get; set; }

    //    public DateTime PaymentDate { get; set; }

    //    [Required, MaxLength(50)]
    //    public string PaymentMethod { get; set; }
    //}

    //public class Category
    //{
    //    [Key]
    //    public int CategoryId { get; set; }

    //    [Required, MaxLength(100)]
    //    public string Name { get; set; }

    //    public ICollection<Product> Products { get; set; }
    //}
}


