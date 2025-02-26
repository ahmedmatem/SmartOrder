using Microsoft.AspNetCore.Mvc;
using SmartOrder.Services.Data.Interfaces;
using SmartOrder.Web.ViewModels.Cart;

namespace SmartOrder.Web.Controllers
{
    public class CartController : BaseController
    {
        private readonly ICartService cartService;

        public CartController(ICartService cartService)
        {
            this.cartService = cartService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            IEnumerable<CartItemViewModel> cartItems = await cartService.GetCartAsync();
            return View(cartItems);
        }

        [HttpGet]
        public async Task<IActionResult> GetCartItems()
        {
            var cartItems = await cartService.GetCartAsync() ?? new List<CartItemViewModel>();

            var response = new
            {
                items = cartItems.Select(item => new
                {
                    MenuItemId = item.MenuItemId,
                    Title = item.Title ?? "No title",
                    Quantity = item.Quantity,
                    Price = item.Price.ToString("F2"), // Ensure decimal formatting
                    TotalPrice = (item.Price * item.Quantity).ToString("F2") // Compute total
                }).ToList(),
                total = cartItems.Sum(item => item.Price * item.Quantity).ToString("F2")
            };

            return Json(response);
        }


        [HttpPost]
        public async Task<IActionResult> AddToCart([FromBody] CartItemViewModel item)
        {
            if (item == null || string.IsNullOrWhiteSpace(item.MenuItemId) || item.Quantity <= 0)
            {
                return BadRequest(new { message = "Invalid item details" });
            }

            await cartService.AddToCartAsync(item);
            return Ok(new { message = "Item added to cart" });
        }

        [HttpPost]
        public async Task<IActionResult> RemoveFromCart([FromBody] string id)
        {
            if (string.IsNullOrWhiteSpace(id) || !Guid.TryParse(id, out Guid menuItemGuid))
            {
                return BadRequest(new { message = "Invalid menu item ID" });
            }

            await cartService.RemoveFromCartAsync(menuItemGuid);
            return Ok(new { message = "Item removed from cart" });
        }

        [HttpPost]
        public async Task<IActionResult> ClearCart()
        {
            await cartService.ClearCartAsync();
            return Ok(new { message = "Cart cleared" });
        }
    }
}
