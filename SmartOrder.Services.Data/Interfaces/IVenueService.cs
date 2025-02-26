using SmartOrder.Web.ViewModels.Venue;

namespace SmartOrder.Services.Data.Interfaces
{
    public interface IVenueService
    {
        Task<IEnumerable<VenueViewModel>> GetAllVenuesAsync();
        Task<bool> AddVenueAsync(VenueViewModel venue);
        Task<bool> DeleteVenueAsync(Guid venueId);
    }
}
