using SmartOrder.Data.Models;
using SmartOrder.Web.ViewModels.Order;

namespace SmartOrder.Services.Data.Interfaces
{
    public interface IOrderService
    {
        Task<IEnumerable<OrderListViewModel>> GetAllOrdersAsync();
        Task<IEnumerable<OrderListViewModel>> GetOrdersByVenueAsync(Guid? venueId);
        Task<bool> CreateOrderAsync(OrderCreateViewModel viewModel);
        Task<OrderDetailsViewModel> GetOrderByIdAsync(Guid id);
        Task<IEnumerable<OrderListViewModel>> GetPendingOrdersByVenueAsync(string venueId);
        Task<bool> UpdateOrderStatusAsync(Guid orderId, string status);
    }
}
