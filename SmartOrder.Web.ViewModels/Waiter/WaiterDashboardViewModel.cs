using SmartOrder.Web.ViewModels.Order;

namespace SmartOrder.Web.ViewModels.Waiter
{
    public class WaiterDashboardViewModel
    {
        public ICollection<OrderDetailsViewModel> UnclaimedOrders { get; set; } = new List<OrderDetailsViewModel>();
        public ICollection<OrderDetailsViewModel> WaiterOrders { get; set; } = new List<OrderDetailsViewModel>();
    }
}
