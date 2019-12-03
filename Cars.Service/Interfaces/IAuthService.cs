using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Cars.Service.Interfaces
{
    public interface IAuthService
    {
        IEnumerable<IdentityRole> GetRoles();
        Task<IdentityResult> CreateRole(IdentityRole role);
        Task<IdentityResult> UpdateRole(IdentityRole role);
        Task<IdentityRole> GetRole(string id);
    }
}
