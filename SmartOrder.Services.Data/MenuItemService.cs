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

        public async Task<MenuItemViewModel?> GetMenuItemByIdAsync(Guid menuItemId)
        {
            MenuItem? menuItem = await menuRepository
                .GetAllAttached()
                .Include(m => m.MenuCategory)
                .FirstOrDefaultAsync(m => m.Id == menuItemId);

            if (menuItem == null)
            {
                return null;
            }

            return new MenuItemViewModel
            {
                Id = menuItem.Id.ToString(),
                Title = menuItem.Title,
                Description = menuItem.Description,
                Price = menuItem.Price,
                ImageUrl = menuItem.ImageUrl,
                MenuCategoryId = menuItem.MenuCategoryId.ToString(),
                MenuCategoryTitle = menuItem.MenuCategory.Title
            };
        }

        public async Task<bool> UpdateMenuItemAsync(MenuItemViewModel menuItemViewModel)
        {
            Guid menuItemGuid = Guid.Empty;
            if (!IsGuidValid(menuItemViewModel.Id, ref menuItemGuid))
            {
                return false;
            }

            MenuItem? menuItem = await menuRepository.GetByIdAsync(menuItemGuid);
            if (menuItem == null)
            {
                return false;
            }

            menuItem.Title = menuItemViewModel.Title;
            menuItem.Description = menuItemViewModel.Description;
            menuItem.Price = menuItemViewModel.Price;
            menuItem.ImageUrl = menuItemViewModel.ImageUrl;

            await menuRepository.UpdateAsync(menuItem);
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

        public async Task<IEnumerable<MenuItemViewModel>> GetMenuItemsByVenueAsync(Guid? venueId)
        {
            IEnumerable<MenuItem> menuItems = await menuRepository
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
