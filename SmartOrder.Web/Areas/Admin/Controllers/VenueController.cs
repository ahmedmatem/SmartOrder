using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartOrder.Services.Data.Interfaces;
using SmartOrder.Web.Controllers;
using SmartOrder.Web.ViewModels.Venue;

namespace SmartOrder.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class VenueController : BaseController
    {
        private readonly IVenueService venueService;

        public VenueController(IVenueService venueService)
        {
            this.venueService = venueService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            IEnumerable<VenueViewModel> venues = await venueService.GetAllVenuesAsync();
            return View(venues);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(string id)
        {
            Guid venueGuid = Guid.Empty;
            if (!IsGuidValid(id, ref venueGuid))
            {
                return RedirectToAction(nameof(Index));
            }

            bool success = await venueService.DeleteVenueAsync(venueGuid);
            if (!success)
            {
                return NotFound();
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
