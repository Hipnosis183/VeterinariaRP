﻿using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using VeterinariaRP.Web.Data.Entities;

namespace VeterinariaRP.Web.Helpers
{
    public interface IUserHelper
    {
        Task<User> GetUserByEmailAsync(string Email);

        Task<IdentityResult> AddUserAsync(User User, string Password);

        Task CheckRoleAsync(string RoleName);

        Task AddUserToRoleAsync(User User, string RoleName);

        Task<bool> IsUserInRoleAsync(User User, string RoleName);
    }
}
