using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace SmartOrder.Data.Models
{
    public class OrderItem
    {
        [Required]
        [Comment("Order item Identifier")]
        public Guid Id { get; set; }

        [Required]
        [Comment("Order Identifier")]
        public Guid OrderId { get; set; }

        [ForeignKey(nameof(OrderId))]
        public Order Order { get; set; } = null!;

        [Required]
        [Comment("Menu Item Identifier")]
        public Guid MenuItemId { get; set; }

        [ForeignKey(nameof(MenuItemId))]
        [DeleteBehavior(DeleteBehavior.Restrict)]
        public MenuItem MenuItem { get; set; } = null!;

        [Comment("Quantity of the item ordered.")]
        public int Quantity { get; set; }

        [Comment("Additional notes or comments about the item.")]
        public string Notes { get; set; } = string.Empty;

        [Comment("Is item served by waiter")]
        public bool IsServed { get; set; } = false;

        [NotMapped]
        public decimal TotalPrice => Quantity * MenuItem.Price;
    }
}