using System.ComponentModel.DataAnnotations;
using static SmartOrder.Common.EntityValidationConstants.OrderItem;

namespace SmartOrder.Web.ViewModels.OrderItem
{
    public class OrderItemCreateViewModel
    {
        [Required]
        public string MenuItemId { get; set; } = null!;
        public string MenuItemTitle { get; set; } = null!;

        [Required]
        [Range(QuantityMinValue, QuantityMaxValue)]
        public int Quantity { get; set; }
    }
}
