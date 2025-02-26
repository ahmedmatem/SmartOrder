using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartOrder.Services.Data.Interfaces;
using SmartOrder.Web.ViewModels.Order;
using static SmartOrder.Web.Infrastructure.Extensions.ClaimsPrincipalExtensions;

namespace SmartOrder.Web.Controllers
{
    [Authorize(Roles = "Admin,Manager,Waiter")]
    public class OrderController : BaseController
    {
        private readonly IOrderService orderService;

        public OrderController(IOrderService orderService)
        {
            this.orderService = orderService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            IEnumerable<OrderListViewModel> orders = await orderService.GetAllOrdersAsync();
            return View(orders);
        }

        [HttpGet]
        public async Task<IActionResult> Details(string? id)
        {
            Guid orderId = Guid.Empty;
            if (!IsGuidValid(id, ref orderId))
            {
                return this.RedirectToAction(nameof(Index));
            }

            OrderDetailsViewModel order = await orderService.GetOrderByIdAsync(orderId);
            if (order == null)
            {
                return this.RedirectToAction(nameof(Index));
            }

            if (User.IsInRole("Waiter") && order.AssignedWaiterId != this.User.GetUserId())
            {
                return this.RedirectToAction(nameof(Index));
            }

            return View(order);
        }
    }
}
