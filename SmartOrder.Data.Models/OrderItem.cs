using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static SmartOrder.Common.EntityValidationConstants.OrderItem;
namespace SmartOrder.Data.Models
{
    public class OrderItem
    {
        [Required]
        [Comment("Order item Identifier")]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        [Comment("Order Identifier")]
        public Guid OrderId { get; set; }

        [ForeignKey(nameof(OrderId))]
        public Order Order { get; set; } = null!;

        [Comment("Quantity of the item ordered.")]
        public int Quantity { get; set; }

        [MaxLength(NameMaxLength)]
        [Comment("Item name.")]
        public string Name { get; set; } = string.Empty;

        [Column(TypeName = "decimal(18, 2)")]
        [Comment("Price of a single unit of the item.")]
        public decimal UnitPrice { get; set; }

        [Comment("Additional notes or comments about the item.")]
        public string Notes { get; set; } = string.Empty;

        [NotMapped]
        public decimal TotalPrice => Quantity * UnitPrice;
    }
}