using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartOrder.Data.Models;
using SmartOrder.Services.Data.Interfaces;
using SmartOrder.Web.Controllers;
using SmartOrder.Web.Infrastructure.Extensions;
using SmartOrder.Web.ViewModels.Order;
using SmartOrder.Web.ViewModels.User;

namespace SmartOrder.Web.Areas.Manager.Controllers
{
    [Area("Manager")]
    [Authorize(Roles = "Manager")]
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
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Orders()
        {
            ApplicationUser? manager = await userService.GetUserByIdAsync(this.User.GetUserId()!);

            IEnumerable<OrderListViewModel> orders = await orderService.GetOrdersByVenueAsync(manager!.VenueId);
            return View(orders);
        }

        [HttpGet]
        public async Task<IActionResult> Staff()
        {
            ApplicationUser? manager = await userService.GetUserByIdAsync(this.User.GetUserId()!);

            IEnumerable<UserViewModel> staff = await userService.GetUsersByVenueAsync(manager!.VenueId);
            return View(staff);
        }
    }
}
