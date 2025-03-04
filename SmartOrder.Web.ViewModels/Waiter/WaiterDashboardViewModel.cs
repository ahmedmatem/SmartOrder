using SmartOrder.Web.ViewModels.Order;

namespace SmartOrder.Web.ViewModels.Waiter
{
    public class WaiterDashboardViewModel
    {
        public List<OrderListViewModel> UnclaimedOrders { get; set; } = new List<OrderListViewModel>();
        public List<OrderListViewModel> WaiterOrders { get; set; } = new List<OrderListViewModel>();
    }
}
