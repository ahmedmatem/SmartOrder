using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SmartOrder.Data.Models;
using SmartOrder.Data.Repository.Interfaces;
using SmartOrder.Services.Data.Interfaces;
using SmartOrder.Web.ViewModels.User;

namespace SmartOrder.Services.Data
{
    public class UserService : BaseService, IUserService
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly RoleManager<IdentityRole<Guid>> roleManager;

        public UserService(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole<Guid>> roleManager)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
        }

        public async Task<IEnumerable<UserViewModel>> GetAllUsersAsync()
        {
            List<ApplicationUser> users = userManager.Users.ToList();
            Dictionary<string, string> userRoles = new Dictionary<string, string>();

            foreach (var user in users)
            {
                IList<string> roles = await userManager.GetRolesAsync(user);
                userRoles[user.Id.ToString()] = roles.FirstOrDefault() ?? "No Role";
            }

            return users.Select(user => new UserViewModel
            {
                Id = user.Id.ToString(),
                FullName = user.FullName,
                Email = user.Email,
                Role = userRoles[user.Id.ToString()]
            });
        }

        public async Task<IEnumerable<UserViewModel>> GetUsersByVenueAsync(Guid? venueId)
        {
            List<ApplicationUser> users = await userManager.Users.Where(u => u.VenueId == venueId).ToListAsync();
            Dictionary<string, string> userRoles = new Dictionary<string, string>();

            foreach (var user in users)
            {
                IList<string> roles = await userManager.GetRolesAsync(user);
                userRoles[user.Id.ToString()] = roles.FirstOrDefault() ?? "No Role";
            }

            return users.Select(user => new UserViewModel
            {
                Id = user.Id.ToString(),
                FullName = user.FullName,
                Email = user.Email,
                Role = userRoles[user.Id.ToString()]
            });
        }

        public async Task<ApplicationUser?> GetUserByIdAsync(string userId)
        {
            Guid userGuid = Guid.Empty;
            if (!IsGuidValid(userId, ref userGuid))
            {
                return null;
            }

            ApplicationUser? user = await userManager.Users.FirstOrDefaultAsync(u => u.Id == userGuid);

            if (user == null)
            {
                return null;
            }

            return user;
        }

        public async Task<IEnumerable<string?>> GetAllRolesAsync()
        {
            return await roleManager.Roles.Select(r => r.Name).ToListAsync();
        }

        public async Task<bool> AssignRoleAsync(Guid userId, string roleName)
        {
            ApplicationUser? user = await userManager.FindByIdAsync(userId.ToString());
            if (user == null)
            {
                return false;
            }

            IList<string> currentRoles = await userManager.GetRolesAsync(user);
            if (currentRoles.Any())
            {
                await userManager.RemoveFromRolesAsync(user, currentRoles);
            }

            IdentityResult result = await userManager.AddToRoleAsync(user, roleName);
            return result.Succeeded;
        }

        public async Task<bool> DeleteUserAsync(Guid userId)
        {
            ApplicationUser? user = await userManager.FindByIdAsync(userId.ToString());
            if (user == null)
            {
                return false;
            }

            IdentityResult result = await userManager.DeleteAsync(user);
            return result.Succeeded;
        }
    }
}
