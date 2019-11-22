using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Cars.Service.Data;
using Cars.Service.Models;
using Cars.Service.Services;
using Cars.Service.Interfaces;

namespace Cars.Controllers
{
    public class VehicleMakeController : Controller
    {

        private readonly ICarService _carService;
        private readonly int _pageSize = 5;

        public VehicleMakeController(ICarService carService)
        {

            _carService = carService;
        }     

        public async Task<IActionResult> Index(string sortBy, int currentPage = 1)
        {
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortBy) ? "Name_desc" : "";
            ViewBag.AbrvSortParm = String.IsNullOrEmpty(sortBy) ? "Abrv_desc" : "";
            ViewBag.CurrentPage = currentPage;
            var vehicleMakes = await _carService.GetVehicleMakesPagedAsync(currentPage, _pageSize);
            switch (sortBy)
            {
                case "Name_desc":
                    vehicleMakes = vehicleMakes.OrderByDescending(s => s.Name);
                    break;
                case "Abrv_desc":
                    vehicleMakes = vehicleMakes.OrderByDescending(s => s.Abrv);
                    break;
                default:
                    vehicleMakes = vehicleMakes.OrderBy(s => s.Name);
                    break;
            }
            return View(vehicleMakes);
        }

        public async Task<IActionResult> Next (int currentPage)
        {
            var page = currentPage;
            var count = await _carService.GetVehicleMakesCount();
            if ( (currentPage + 1 ) * _pageSize <= count)
            {
                page += 1;
            }
            return RedirectToAction("Index", new { currentPage = page });
        }

        public async Task<IActionResult> Previous(int currentPage)
        {
            var page = currentPage;
            if (currentPage > 1)
            {
                page--;
                                }
            return RedirectToAction("Index", new { currentPage = page });
        }
        // GET: VehicleMakes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehicleMake = await _carService.GetVehicleMakeAsync(id);
            if (vehicleMake == null)
            {
                return NotFound();
            }

            return View(vehicleMake);
        }



        // GET: VehicleMakes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: VehicleMakes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Abrv")] VehicleMake vehicleMake)
        {
            if (ModelState.IsValid)
            {
                var numberOfSaves = await _carService.CreateVehicleMakeAsync(vehicleMake);
                if (numberOfSaves > 0)
                {
                    return RedirectToAction(nameof(Index));
                }
                return View(vehicleMake);

            }
            return View(vehicleMake);
        }


        // GET: VehicleMakes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehicleMake = await _carService.FindVehicleMakeAsync(id);
            if (vehicleMake == null)
            {
                return NotFound();
            }
            return View(vehicleMake);
        }

        // POST: VehicleMakes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Abrv")] VehicleMake vehicleMake)
        {
            if (id != vehicleMake.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var numberOfChanges = await _carService.UpdateVehicleMakeAsync(vehicleMake);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_carService.VehicleMakeExists(vehicleMake.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(vehicleMake);
        }


        // GET: VehicleMakes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehicleMake = await _carService.FindVehicleMakeAsync(id);

            if (vehicleMake == null)
            {
                return NotFound();
            }

            return View(vehicleMake);
        }

        // POST: VehicleMakes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        //[HttpDelete]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var vehicleMake = await _carService.DeleteVehicleMakeAsync(id);

            return RedirectToAction(nameof(Index));
        }




    }
}
