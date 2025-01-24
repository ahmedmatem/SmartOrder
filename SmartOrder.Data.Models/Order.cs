using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartOrder.Data.Models
{
    public class Order
    {
        [Required]
        [Comment("Order Identifier")]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        [Comment("Order table Identifier")]
        public Guid TableId { get; set; }

        [ForeignKey(nameof(TableId))]
        public Table Table { get; set; } = null!;

        [Comment("Status of the order {e.g., Pending, Completed, Cancelled, …}")]
        public int OrderStatus { get; set; }

        [NotMapped]
        public decimal TotalPrice => Items?.Sum(oi => oi.TotalPrice) ?? 0;

        public ICollection<OrderItem> Items { get; set; } = new List<OrderItem>();
    }
}
