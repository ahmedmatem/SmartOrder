using SmartOrder.Web.ViewModels.OrderItem;

namespace SmartOrder.Web.ViewModels.Order
{
    public class OrderDetailsViewModel
    {
        public string Id { get; set; } = null!;
        public int TableNumber { get; set; }
        public string Status { get; set; } = null!;
        public string? AssignedWaiterId { get; set; }
        public string? AssignedWaiter { get; set; }
        public decimal TotalPrice { get; set; }
        public List<OrderItemDetailsViewModel> Items { get; set; } = new();
    }
}
