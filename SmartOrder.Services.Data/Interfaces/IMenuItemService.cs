using SmartOrder.Web.ViewModels.MenuItem;

namespace SmartOrder.Services.Data.Interfaces
{
    public interface IMenuItemService
    {
        Task<bool> AddMenuItemAsync(MenuItemViewModel menuItem);
        Task<MenuItemViewModel?> GetMenuItemByIdAsync(Guid menuItemId);
        Task<bool> UpdateMenuItemAsync(MenuItemViewModel menuItemViewModel);
        Task<bool> DeleteMenuItemAsync(Guid menuItemId);
        Task<IEnumerable<MenuItemViewModel>> GetMenuItemsByVenueAsync(Guid? venueId);
    }
}
