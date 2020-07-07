using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using VeterinariaRP.Web.Data.Entities;

namespace VeterinariaRP.Web.Helpers
{
    public class UserHelper : IUserHelper
    {
        private readonly UserManager<User> _UserManager;
        private readonly RoleManager<IdentityRole> _RoleManager;

        public UserHelper(UserManager<User> UserManager, RoleManager<IdentityRole> RoleManager)
        {
            _UserManager = UserManager;
            _RoleManager = RoleManager;
        }

        public async Task<IdentityResult> AddUserAsync(User User, string Password)
        {
            return await _UserManager.CreateAsync(User, Password);
        }

        public async Task AddUserToRoleAsync(User User, string RoleName)
        {
            await _UserManager.AddToRoleAsync(User, RoleName);
        }

        public async Task CheckRoleAsync(string RoleName)
        {
            bool RoleExists = await _RoleManager.RoleExistsAsync(RoleName);

            if (!RoleExists)
            {
                await _RoleManager.CreateAsync(new IdentityRole
                {
                    Name = RoleName
                }) ;
            }
        }

        public async Task<User> GetUserByEmailAsync(string Email)
        {
            User User = await _UserManager.FindByEmailAsync(Email);

            return User;
        }

        public async Task<bool> IsUserInRoleAsync(User User, string RoleName)
        {
            return await _UserManager.IsInRoleAsync(User, RoleName);
        }
    }
}
