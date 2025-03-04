using Microsoft.EntityFrameworkCore;
using SmartOrder.Data.Models;
using SmartOrder.Data.Repository.Interfaces;
using SmartOrder.Services.Data.Interfaces;
using SmartOrder.Web.ViewModels.Venue;

namespace SmartOrder.Services.Data
{
    public class VenueService : IVenueService
    {
        private readonly IRepository<Venue, Guid> venueRepository;

        public VenueService(IRepository<Venue, Guid> venueRepository)
        {
            this.venueRepository = venueRepository;
        }

        public async Task<IEnumerable<VenueViewModel>> GetAllVenuesAsync()
        {
            IEnumerable<Venue> venues = await venueRepository.GetAllAttached().ToListAsync();

            return venues.Select(v => new VenueViewModel
            {
                Id = v.Id.ToString(),
                Name = v.Name,
                Type = v.Type,
                City = v.City,
                CreatedOn = v.CreatedOn
            });
        }

        public async Task<bool> AddVenueAsync(VenueViewModel venueViewModel)
        {
            Venue venue = new Venue
            {
                Id = Guid.Parse(venueViewModel.Id),
                Name = venueViewModel.Name,
                Type = venueViewModel.Type,
                City = venueViewModel.City,
                CreatedOn = DateTime.UtcNow
            };

            await venueRepository.AddAsync(venue);
            return true;
        }

        public async Task<bool> DeleteVenueAsync(Guid venueId)
        {
            Venue venue = await venueRepository.GetByIdAsync(venueId);
            if (venue == null)
            {
                return false;
            }

            await venueRepository.DeleteAsync(venue);
            return true;
        }
    }
}
