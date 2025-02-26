using SmartOrder.Web.ViewModels.Order;

namespace SmartOrder.Web.ViewModels.Waiter
{
    public class WaiterDashboardViewModel
    {
        public List<OrderListViewModel> Orders { get; set; } = new List<OrderListViewModel>();
    }
}
