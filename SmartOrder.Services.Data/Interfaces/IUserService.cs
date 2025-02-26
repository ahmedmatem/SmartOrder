using SmartOrder.Data.Models;
using SmartOrder.Web.ViewModels.User;

namespace SmartOrder.Services.Data.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<UserViewModel>> GetAllUsersAsync();
        Task<IEnumerable<UserViewModel>> GetUsersByVenueAsync(Guid? venueId);
        Task<ApplicationUser?> GetUserByIdAsync(string userId);
        Task<IEnumerable<string?>> GetAllRolesAsync();
        Task<bool> AssignRoleAsync(Guid userId, string roleName);
        Task<bool> DeleteUserAsync(Guid userId);
    }
}
