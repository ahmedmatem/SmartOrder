using SmartOrder.Web.ViewModels.OrderItem;
using System.ComponentModel.DataAnnotations;

namespace SmartOrder.Web.ViewModels.Order
{
    public class OrderCreateViewModel
    {
        [Required]
        public string TableId { get; set; } = null!;

        public List<OrderItemCreateViewModel> Items { get; set; } = new();
    }
}
