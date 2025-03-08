using Microsoft.AspNetCore.Mvc;
using SmartOrder.Services.Data.Interfaces;
using SmartOrder.Web.ViewModels.MenuItem;

namespace SmartOrder.Web.Controllers
{
    public class MenuItemController : BaseController
    {
        private readonly IMenuItemService menuService;
        private readonly ITableService tableService;
        private readonly IMenuCategoryService menuCategoryService;

        public MenuItemController(IMenuItemService menuService, ITableService tableService, IMenuCategoryService menuCategoryService)
        {
            this.menuService = menuService;
            this.tableService = tableService;
            this.menuCategoryService = menuCategoryService;
        }

        [HttpGet]
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

    }
}
