using SmartOrder.Web.ViewModels.Order;

namespace SmartOrder.Services.Data.Interfaces
{
    public interface IOrderService
    {
        Task<IEnumerable<OrderDetailsViewModel>> GetOrdersByVenueAsync(Guid? venueId);
        Task<bool> CreateOrderAsync(OrderCreateViewModel viewModel);
        Task<bool> AssignOrderToWaiterAsync(Guid orderId, Guid waiterId);
        Task<bool> UpdateOrderStatusAsync(Guid orderId, string status);
    }
}
