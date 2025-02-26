using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartOrder.Services.Data.Interfaces;
using SmartOrder.Web.Controllers;
using SmartOrder.Web.ViewModels.Order;

namespace SmartOrder.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class HomeController : BaseController
    {
        private readonly IOrderService orderService;
        private readonly IUserService userService;

        public HomeController(IOrderService orderService, IUserService userService)
        {
            this.orderService = orderService;
            this.userService = userService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Orders()
        {
            IEnumerable<OrderListViewModel> orders = await orderService.GetAllOrdersAsync();
            return View(orders);
        }

        [HttpGet]
        public async Task<IActionResult> Users()
        {
            var users = await userService.GetAllUsersAsync();
            ViewBag.Roles = await userService.GetAllRolesAsync();
            return View(users);
        }

        [HttpPost]
        public async Task<IActionResult> AssignRole(string userId, string roleName)
        {
            Guid userGuid = Guid.Empty;
            if (!IsGuidValid(userId, ref userGuid) || string.IsNullOrEmpty(roleName))
            {
                return BadRequest("Invalid user ID or role name.");
            }

            bool success = await userService.AssignRoleAsync(userGuid, roleName);
            if (!success)
            {
                return BadRequest("Failed to assign role.");
            }

            return RedirectToAction(nameof(Users));
        }

        [HttpPost]
        public async Task<IActionResult> DeleteUser(string id)
        {
            Guid userGuid = Guid.Empty;
            if (!IsGuidValid(id, ref userGuid))
            {
                return RedirectToAction(nameof(Users));
            }

            bool success = await userService.DeleteUserAsync(userGuid);
            if (!success)
            {
                return NotFound();
            }

            return RedirectToAction(nameof(Users));
        }
    }
}
