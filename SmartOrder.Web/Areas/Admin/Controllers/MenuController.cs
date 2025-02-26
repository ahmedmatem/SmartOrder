using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartOrder.Services.Data.Interfaces;
using SmartOrder.Web.Controllers;
using SmartOrder.Web.ViewModels.MenuItem;

namespace SmartOrder.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin,Manager")]
    public class MenuController : BaseController
    {
        private readonly IMenuItemService menuService;

        public MenuController(IMenuItemService menuService)
        {
            this.menuService = menuService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            IEnumerable<MenuItemViewModel> menuItems = await menuService.GetAllMenuItemsAsync();
            return View(menuItems);
        }

        [HttpPost]
        public async Task<IActionResult> Add(MenuItemViewModel menuItem)
        {
            if (!ModelState.IsValid)
            {
                return View(nameof(Index), await menuService.GetAllMenuItemsAsync());
            }

            await menuService.AddMenuItemAsync(menuItem);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> Delete(string id)
        {
            Guid menuItemGuid = Guid.Empty;
            if (!IsGuidValid(id, ref menuItemGuid))
            {
                return RedirectToAction(nameof(Index));
            }

            bool success = await menuService.DeleteMenuItemAsync(menuItemGuid);
            if (!success)
            {
                return NotFound();
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
