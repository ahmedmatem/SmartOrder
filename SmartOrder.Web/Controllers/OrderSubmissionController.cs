using Microsoft.AspNetCore.Mvc;
using SmartOrder.Services.Data.Interfaces;
using SmartOrder.Web.ViewModels.Cart;
using SmartOrder.Web.ViewModels.Order;
using SmartOrder.Web.ViewModels.OrderItem;

namespace SmartOrder.Web.Controllers
{
    public class OrderSubmissionController : BaseController
    {
        private readonly ICartService cartService;
        private readonly IOrderService orderService;
        private readonly ITableService tableService;

        public OrderSubmissionController(ICartService cartService, IOrderService orderService, ITableService tableService)
        {
            this.cartService = cartService;
            this.orderService = orderService;
            this.tableService = tableService;
        }

        [HttpGet]
        public async Task<IActionResult> Checkout(string token)
        {
            Guid tableGuid = await this.tableService.GetTableIdByTokenAsync(token);
            if (tableGuid == Guid.Empty)
            {
                return BadRequest("Invalid table token.");
            }

            IEnumerable<CartItemViewModel> cartItems = await cartService.GetCartAsync();
            if (!cartItems.Any())
            {
                ModelState.AddModelError("", "Your cart is empty.");
                return View(nameof(Checkout), token);
            }

            var viewModel = new OrderCreateViewModel
            {
                TableId = tableGuid.ToString(),
                Items = cartItems.Select(i => new OrderItemCreateViewModel
                {
                    MenuItemId = i.MenuItemId,
                    MenuItemTitle = i.Title,
                    Quantity = i.Quantity,
                }).ToList()
            };

            return View(nameof(SubmitOrder), viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> SubmitOrder(OrderCreateViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(nameof(Checkout), viewModel);
            }

            Guid tableGuid = Guid.Empty;
            if (!IsGuidValid(viewModel.TableId, ref tableGuid))
            {
                return View(nameof(Checkout), viewModel);
            }

            bool success = await orderService.CreateOrderAsync(viewModel);
            if (!success)
            {
                ModelState.AddModelError("", "Error creating order. Please check your internet connection and try again.");
                return View(nameof(Checkout), viewModel);
            }

            string token = await this.tableService.GetTokenByTableIdAsync(tableGuid);

            await cartService.ClearCartAsync();
            return RedirectToAction(nameof(OrderConfirmation), new { token = token });
        }

        [HttpGet]
        public IActionResult OrderConfirmation(string token)
        {
            ViewBag.Token = token;
            return View();
        }
    }
}
