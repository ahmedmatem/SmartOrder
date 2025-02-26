using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartOrder.Data.Models;
using SmartOrder.Services.Data;
using SmartOrder.Services.Data.Interfaces;
using SmartOrder.Web.Controllers;
using SmartOrder.Web.Infrastructure.Extensions;
using SmartOrder.Web.ViewModels.Table;

namespace SmartOrder.Web.Areas.Manager.Controllers
{
    [Area("Manager")]
    [Authorize(Roles = "Manager")]
    public class TableController : BaseController
    {
        private readonly ITableService tableService;
        private readonly IUserService userService;

        public TableController(ITableService tableService, IUserService userService)
        {
            this.tableService = tableService;
            this.userService = userService;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            ApplicationUser? manager = await userService.GetUserByIdAsync(this.User.GetUserId()!);

            IEnumerable<TableViewModel> tables = await tableService.GetAllTablesAsync(manager!.VenueId.ToString()!);
            return View(tables);
        }

        [HttpPost]
        public async Task<IActionResult> Add(TableViewModel table)
        {
            if (!ModelState.IsValid)
            {
                ApplicationUser? manager = await userService.GetUserByIdAsync(this.User.GetUserId()!);

                return View(nameof(Index), await tableService.GetAllTablesAsync(manager!.VenueId.ToString()!));
            }

            await tableService.AddTableAsync(table);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> Delete(string id)
        {
            Guid tableGuid = Guid.Empty;
            if (!IsGuidValid(id, ref tableGuid))
            {
                return RedirectToAction(nameof(Index));
            }

            bool success = await tableService.DeleteTableAsync(tableGuid);
            if (!success)
            {
                return NotFound();
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
