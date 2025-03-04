using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartOrder.Data.Models;
using SmartOrder.Services.Data;
using SmartOrder.Services.Data.Interfaces;
using SmartOrder.Web.Controllers;
using SmartOrder.Web.Infrastructure.Extensions;
using SmartOrder.Web.ViewModels.MenuItem;

namespace SmartOrder.Web.Areas.Manager.Controllers
{
    [Area("Manager")]
    [Authorize(Roles = "Manager")]
    public class MenuItemController : BaseController
    {
        private readonly IMenuItemService menuService;
        private readonly IUserService userService;
        private readonly ITableService tableService;
        private readonly IMenuCategoryService menuCategoryService;

        public MenuItemController(IMenuItemService menuService, IUserService userService, ITableService tableService, IMenuCategoryService menuCategoryService)
        {
            this.menuService = menuService;
            this.userService = userService;
            this.tableService = tableService;
            this.menuCategoryService = menuCategoryService;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Index(string token)
        {
            Guid? venueId = await tableService.GetVenueIdByTableTokenAsync(token);
            if (venueId == null)
            {
                return BadRequest("Invalid Table Token");
            }

            IEnumerable<MenuItemViewModel> menuItems = await menuService.GetMenuItemsByVenueAsync(venueId.Value);
            ViewBag.Categories = await menuCategoryService.GetAllMenuCategoriesByVenueAsync(venueId);
            ViewBag.Token = token;
            return View(menuItems);
        }

        [HttpGet]
        public async Task<IActionResult> Manage()
        {
            ApplicationUser? manager = await userService.GetUserByIdAsync(this.User.GetUserId()!);

            IEnumerable<MenuItemViewModel> menuItems = await menuService.GetMenuItemsByVenueAsync(manager!.VenueId);
            return View(menuItems);
        }

        [HttpPost]
        public async Task<IActionResult> Add(MenuItemViewModel menuItem)
        {
            if (!ModelState.IsValid)
            {
                return View(nameof(Manage));
            }

            await menuService.AddMenuItemAsync(menuItem);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            Guid menuItemGuid = Guid.Empty;
            if (!IsGuidValid(id, ref menuItemGuid))
            {
                return RedirectToAction(nameof(Manage));
            }

            MenuItemViewModel? menuItem = await menuService.GetMenuItemByIdAsync(menuItemGuid);
            if (menuItem == null)
            {
                return NotFound();
            }

            return View(menuItem);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(MenuItemViewModel menuItem)
        {
            if (!ModelState.IsValid)
            {
                return View(menuItem);
            }

            bool success = await menuService.UpdateMenuItemAsync(menuItem);
            if (!success)
            {
                return NotFound();
            }

            return RedirectToAction(nameof(Manage));
        }

        [HttpPost]
        public async Task<IActionResult> Delete(string id)
        {
            Guid menuItemGuid = Guid.Empty;
            if (!IsGuidValid(id, ref menuItemGuid))
            {
                return RedirectToAction(nameof(Manage));
            }

            bool success = await menuService.DeleteMenuItemAsync(menuItemGuid);
            if (!success)
            {
                return NotFound();
            }

            return RedirectToAction(nameof(Manage));
        }
    }
}
