using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartOrder.Data.Models;
using SmartOrder.Services.Data.Interfaces;
using SmartOrder.Web.Controllers;
using SmartOrder.Web.Infrastructure.Extensions;
using SmartOrder.Web.ViewModels.Report;

namespace SmartOrder.Web.Areas.Manager.Controllers
{
    [Area("Manager")]
    [Authorize(Roles = "Manager")]
    public class ReportController : BaseController
    {
        private readonly IReportService reportService;
        private readonly IUserService userService;

        public ReportController(IReportService reportService, IUserService userService)
        {
            this.reportService = reportService;
            this.userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> Sales()
        {
            ApplicationUser? manager = await userService.GetUserByIdAsync(this.User.GetUserId()!);

            IEnumerable<SalesReportViewModel> report = await reportService.GetSalesReportAsync(manager!.VenueId.ToString()!);
            return View(report);
        }
    }
}
