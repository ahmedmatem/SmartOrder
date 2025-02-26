using SmartOrder.Web.ViewModels.OrderItem;

namespace SmartOrder.Web.ViewModels.Order
{
    public class OrderListViewModel
    {
        public string Id { get; set; } = null!;

        public int TableNumber { get; set; }

        public string Status { get; set; } = null!;

        public string? AssignedWaiter { get; set; }

        public decimal TotalPrice { get; set; }

    }
}
