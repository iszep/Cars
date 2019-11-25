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
using Cars.Service.Dtos;

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

        public async Task<IActionResult> Index(string sortBy, string searchString, int currentPage = 1)
        {
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortBy) ? "Name_desc" : "";
            ViewBag.AbrvSortParm = String.IsNullOrEmpty(sortBy) ? "Abrv_desc" : "";
            ViewBag.CurrentPage = currentPage;
            ViewBag.SearchString = searchString;
            var vehicleMakes = await _carService.GetVehicleMakesPagedAsync(currentPage, _pageSize, searchString);

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

        [HttpPost]
        public IActionResult Search([Bind("SearchString")] string searchString)
        {
            return RedirectToAction("Index", new { currentPage = 1, searchString });
        }

        public async Task<IActionResult> Next([Bind("SearchString")] string searchString, int currentPage)
        {
            var page = currentPage;
            var count = await _carService.GetVehicleMakesCount();
            if ((currentPage + 1) * _pageSize <= count)
            {
                page += 1;
            }
            return RedirectToAction("Index", new { currentPage = page, searchString });
        }

        public async Task<IActionResult> Previous([Bind("SearchString")] string searchString, int currentPage)
        {
            var page = currentPage;
            if (currentPage > 1)
            {
                await Task.Run(() => page--);
            }
            return RedirectToAction("Index", new { currentPage = page, searchString });
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
        public async Task<IActionResult> Create([Bind("Id,Name,Abrv")] VehicleMakeDto vehicleMakeDto)
        {
            if (ModelState.IsValid)
            {
                var numberOfSaves = await _carService.CreateVehicleMakeAsync(vehicleMakeDto);
                if (numberOfSaves > 0)
                {
                    return RedirectToAction(nameof(Index));
                }
                return View(vehicleMakeDto);

            }
            return View(vehicleMakeDto);
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
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Abrv")] VehicleMakeDto vehicleMakeDto)
        {
            if (id != vehicleMakeDto.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var numberOfChanges = await _carService.UpdateVehicleMakeAsync(vehicleMakeDto);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_carService.VehicleMakeExists(vehicleMakeDto.Id))
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
            return View(vehicleMakeDto);
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
