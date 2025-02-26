using SmartOrder.Web.ViewModels.MenuItem;

namespace SmartOrder.Services.Data.Interfaces
{
    public interface IMenuItemService
    {
        Task<IEnumerable<MenuItemViewModel>> GetAllMenuItemsAsync();
        Task<bool> AddMenuItemAsync(MenuItemViewModel menuItem);
        Task<bool> DeleteMenuItemAsync(Guid menuItemId);
        Task<IEnumerable<MenuItemViewModel>> GetMenuItemsByVenueAsync(Guid venueId);
    }
}
