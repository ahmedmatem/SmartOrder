using Microsoft.EntityFrameworkCore;
using SmartOrder.Data.Models;
using SmartOrder.Data.Repository.Interfaces;
using SmartOrder.Services.Data.Interfaces;
using SmartOrder.Web.ViewModels.MenuCategory;

namespace SmartOrder.Services.Data
{
    public class MenuCategoryService : BaseService, IMenuCategoryService
    {
        private readonly IRepository<MenuCategory, Guid> menuCategoryRepository;

        public MenuCategoryService(IRepository<MenuCategory, Guid> menuCategoryRepository)
        {
            this.menuCategoryRepository = menuCategoryRepository;
        }

        public async Task<IEnumerable<MenuCategoryViewModel>> GetAllMenuCategoriesByVenueAsync(Guid? venueId)
        {
            return await this.menuCategoryRepository
                .GetAllAttached()
                .Where(mc => mc.VenueId == venueId)
                .Select(mc => new MenuCategoryViewModel
                {
                    Id = mc.Id.ToString(),
                    Title = mc.Title,
                })
                .ToListAsync();
        }
    }
}
