using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.FileProviders;
using System.Threading.Tasks;
using VeterinariaRP.Web.Data.Entities;
using VeterinariaRP.Web.Models;

namespace VeterinariaRP.Web.Helpers
{
    public class UserHelper : IUserHelper
    {
        private readonly UserManager<User> _UserManager;
        private readonly RoleManager<IdentityRole> _RoleManager;
        private readonly SignInManager<User> _SignInManager;

        public UserHelper(UserManager<User> UserManager, RoleManager<IdentityRole> RoleManager, SignInManager<User> SignInManager)
        {
            _UserManager = UserManager;
            _RoleManager = RoleManager;
            _SignInManager = SignInManager;
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

        public async Task<SignInResult> LoginAsync(LoginViewModel Model)
        {
            return await _SignInManager.PasswordSignInAsync(Model.NombreUsuario, Model.Password, Model.Recordarme, false);
        }

        public async Task LogoutAsync()
        {
            await _SignInManager.SignOutAsync();
        }

        public async Task<bool> DeleteUserAsync(string Email)
        {
            User Usuario = await GetUserByEmailAsync(Email);

            if (Usuario == null)
            {
                return true;
            }

            IdentityResult Respuesta = await _UserManager.DeleteAsync(Usuario);

            return Respuesta.Succeeded;
        }

        public async Task<IdentityResult> UpdateUserAsync(User User)
        {
            return await _UserManager.UpdateAsync(User);
        }
    }
}
