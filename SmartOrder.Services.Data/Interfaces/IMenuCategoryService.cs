using SmartOrder.Web.ViewModels.MenuCategory;

namespace SmartOrder.Services.Data.Interfaces
{
    public interface IMenuCategoryService
    {
        Task<IEnumerable<MenuCategoryViewModel>> GetAllMenuCategoriesByVenueAsync(Guid? venueId);
    }
}
