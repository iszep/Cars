using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Cars.Service.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace Cars.Service.Services
{
    public class AuthService : IAuthService
    {
        private readonly RoleManager<IdentityRole> _roleManager;

        public AuthService(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }

        public async Task<IdentityResult> CreateRole(IdentityRole role)
        {
            var saved = await _roleManager.CreateAsync(role);
            return saved;
        }

        public Task<IdentityRole> GetRole(string id)
        {
            var role = _roleManager.FindByIdAsync(id);
            return role;
        }

        public IEnumerable<IdentityRole> GetRoles()
        {
            var roles = _roleManager.Roles;
            return roles;
        }

        public Task<IdentityResult> UpdateRole(IdentityRole role)
        {
            var result = _roleManager.UpdateAsync(role);
            return result;
        }
        
    }
}
