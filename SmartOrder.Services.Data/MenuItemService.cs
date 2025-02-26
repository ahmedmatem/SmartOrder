using Microsoft.EntityFrameworkCore;
using SmartOrder.Data.Models;
using SmartOrder.Data.Repository.Interfaces;
using SmartOrder.Services.Data.Interfaces;
using SmartOrder.Web.ViewModels.MenuItem;

namespace SmartOrder.Services.Data
{
    public class MenuItemService : BaseService, IMenuItemService
    {
        private readonly IRepository<MenuItem, Guid> menuRepository;

        public MenuItemService(IRepository<MenuItem, Guid> menuRepository)
        {
            this.menuRepository = menuRepository;
        }

        public async Task<IEnumerable<MenuItemViewModel>> GetAllMenuItemsAsync()
        {
            IEnumerable<MenuItem> menuItems = await menuRepository
                .GetAllAttached()
                .Include(mi => mi.MenuCategory)
                .ToListAsync();

            return menuItems.Select(item => new MenuItemViewModel
            {
                Id = item.Id.ToString(),
                MenuCategoryId = item.MenuCategoryId.ToString(),
                MenuCategoryTitle = item.MenuCategory.Title,
                Title = item.Title,
                Description = item.Description,
                Price = item.Price,
                Tags = item.Tags,
                ImageUrl = item.ImageUrl
            });
        }

        public async Task<bool> AddMenuItemAsync(MenuItemViewModel menuItemViewModel)
        {
            MenuItem menuItem = new MenuItem
            {
                Id = Guid.NewGuid(),
                Title = menuItemViewModel.Title,
                Description = menuItemViewModel.Description,
                Price = menuItemViewModel.Price
            };
            await menuRepository.AddAsync(menuItem);
            return true;
        }

        public async Task<bool> DeleteMenuItemAsync(Guid menuItemId)
        {
            MenuItem menuItem = await menuRepository.GetByIdAsync(menuItemId);
            if (menuItem == null)
            {
                return false;
            }

            await menuRepository.DeleteAsync(menuItem);
            return true;
        }

        public async Task<IEnumerable<MenuItemViewModel>> GetMenuItemsByVenueAsync(Guid venueId)
        {
            var menuItems = await menuRepository
                .GetAllAttached()
                .Include(m => m.MenuCategory)
                .Where(m => m.MenuCategory.VenueId == venueId)
                .ToListAsync();

            return menuItems.Select(m => new MenuItemViewModel
            {
                Id = m.Id.ToString(),
                Title = m.Title,
                Description = m.Description,
                Price = m.Price,
                ImageUrl = m.ImageUrl,
                MenuCategoryId = m.MenuCategoryId.ToString(),
                MenuCategoryTitle = m.MenuCategory.Title
            });
        }
    }
}
