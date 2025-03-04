using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartOrder.Data.Models;
using SmartOrder.Services.Data;
using SmartOrder.Services.Data.Interfaces;
using SmartOrder.Web.Controllers;
using SmartOrder.Web.Infrastructure.Extensions;
using SmartOrder.Web.ViewModels.Order;
using SmartOrder.Web.ViewModels.Waiter;

namespace SmartOrder.Web.Areas.Waiter.Controllers
{
    [Area("Waiter")]
    [Authorize(Roles = "Waiter")]
    public class HomeController : BaseController
    {
        private readonly IOrderService orderService;
        private readonly IUserService userService;

        public HomeController(IOrderService orderService, IUserService userService)
        {
            this.orderService = orderService;
            this.userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            ApplicationUser? waiter = await userService.GetUserByIdAsync(this.User.GetUserId()!);

            if (waiter == null || waiter.VenueId == null)
            {
                return Unauthorized();
            }

            IEnumerable<OrderListViewModel> allOrders = await orderService.GetOrdersByVenueAsync(waiter.VenueId!);

            var unclaimedOrders = allOrders.Where(o => o.AssignedWaiter == "Unassigned").ToList();
            var waiterOrders = allOrders.Where(o => o.AssignedWaiterId == waiter.Id.ToString()).ToList();

            var viewModel = new WaiterDashboardViewModel
            {
                UnclaimedOrders = unclaimedOrders,
                WaiterOrders = waiterOrders
            };

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> ClaimOrder(string id)
        {
            Guid orderGuid = Guid.Empty;
            if (!IsGuidValid(id, ref orderGuid))
            {
                return View(nameof(Index));
            }

            ApplicationUser? waiter = await userService.GetUserByIdAsync(this.User.GetUserId()!);
            if (waiter == null)
            {
                return Unauthorized();
            }

            bool success = await orderService.AssignOrderToWaiterAsync(orderGuid, waiter.Id);
            if (!success)
            {
                return NotFound();
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> UpdateStatus(string id, string status)
        {
            Guid orderGuid = Guid.Empty;
            if (!IsGuidValid(id, ref orderGuid))
            {
                return BadRequest("Wrong order Id!");
            }

            bool success = await orderService.UpdateOrderStatusAsync(orderGuid, status);
            if (!success)
            {
                return NotFound();
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
