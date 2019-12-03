using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cars.Service.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Cars.MVC.Controllers
{
    public class RolesController : Controller
    {
        private readonly IAuthService _authService;

        public RolesController(IAuthService authService)
        {
            _authService = authService;
        }

        public IActionResult Index()
        {
            var roles = _authService.GetRoles();
            return View(roles);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name")] IdentityRole role)
        {
            if (ModelState.IsValid)
            {
                var x = await _authService.CreateRole(role);
                return RedirectToAction(nameof(Index));
            }
            return View(role);
        }
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var role = await _authService.GetRole(id);
            if (role == null)
            {
                return NotFound();
            }
            return View(role);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([Bind("Id", "Name")] IdentityRole role)
        {
            if (ModelState.IsValid)
            {
                var x = await _authService.UpdateRole(role);
                return RedirectToAction(nameof(Index));
            }
            return View(role);
        }
    }
}