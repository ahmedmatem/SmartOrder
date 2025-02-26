using SmartOrder.Web.ViewModels.Cart;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using SmartOrder.Services.Data.Interfaces;

namespace SmartOrder.Services.Data
{
    public class CartService : BaseService, ICartService
    {
        private readonly IHttpContextAccessor httpContextAccessor;
        private const string CartSessionKey = "Cart";

        public CartService(IHttpContextAccessor httpContextAccessor)
        {
            this.httpContextAccessor = httpContextAccessor;
        }

        public async Task AddToCartAsync(CartItemViewModel item)
        {
            List<CartItemViewModel> cart = await GetCartAsync();
            CartItemViewModel? existingItem = cart.FirstOrDefault(i => i.MenuItemId == item.MenuItemId);

            if (existingItem != null)
            {
                existingItem.Quantity += item.Quantity;
            }
            else
            {
                cart.Add(item);
            }

            await SaveCartAsync(cart);
        }

        public async Task RemoveFromCartAsync(Guid menuItemId)
        {
            List<CartItemViewModel> cart = await GetCartAsync();
            cart.RemoveAll(i => i.MenuItemId == menuItemId.ToString());
            await SaveCartAsync(cart);
        }

        public async Task<List<CartItemViewModel>> GetCartAsync()
        {
            ISession? session = httpContextAccessor.HttpContext?.Session;
            string? cartJson = session?.GetString(CartSessionKey);

#pragma warning disable CS8603 // Possible null reference return.
            return string.IsNullOrEmpty(cartJson) 
                ? new List<CartItemViewModel>() 
                : await Task.Run(() => JsonConvert.DeserializeObject<List<CartItemViewModel>>(cartJson));
#pragma warning restore CS8603 // Possible null reference return.
        }

        public async Task ClearCartAsync()
        {
            await SaveCartAsync(new List<CartItemViewModel>());
        }

        private async Task SaveCartAsync(List<CartItemViewModel> cart)
        {
            ISession? session = httpContextAccessor.HttpContext?.Session;
            await Task.Run(() => session?.SetString(CartSessionKey, JsonConvert.SerializeObject(cart)));
        }
    }
}
