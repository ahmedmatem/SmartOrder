using SmartOrder.Web.ViewModels.Cart;

namespace SmartOrder.Services.Data.Interfaces
{
    public interface ICartService
    {
        Task AddToCartAsync(CartItemViewModel item);
        Task RemoveFromCartAsync(Guid menuItemId);
        Task<List<CartItemViewModel>> GetCartAsync();
        Task ClearCartAsync();
    }
}
