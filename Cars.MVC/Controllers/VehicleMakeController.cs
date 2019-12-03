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
using Microsoft.AspNetCore.Routing;

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

        public async Task<IActionResult> Index(int pageindex = 1, string sort = "Name", string search = "")
        {
            var queryParams = new VehicleMakeDtoQuery { PageIndex = pageindex, Sort = sort, Search = search, PageSize = _pageSize };
            var model = await _carService.GetVehicleMakesPagedAsync(queryParams);
            model.RouteValue = new RouteValueDictionary
            {
                { "search", search }
            };
            return View(model);
        }
    
        // GET: VehicleMakes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            try
            {
                var vehicleMake = await _carService.GetVehicleMakeAsync(id);
                return View(vehicleMake);

            }
            catch (Exception)
            {
                return RedirectToAction("Error","Home");
            }        
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
                try
                {
                    var numberOfSaves = await _carService.CreateVehicleMakeAsync(vehicleMakeDto);
                    return RedirectToAction(nameof(Index));
                }
                catch(Exception)
                {
                    return RedirectToAction("Error", "Home");
                }
                

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

            try
            {
                var vehicleMake = await _carService.GetVehicleMakeAsync(id);
                return View(vehicleMake);
            }
            catch (Exception)
            {
                return RedirectToAction("Error", "Home");
            }

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
                catch (Exception)
                {
                    return RedirectToAction("Error", "Home");                
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
            try
            {
                var vehicleMake = await _carService.GetVehicleMakeAsync(id);
                return View(vehicleMake);
            }

            catch (Exception)
            {
                return RedirectToAction("Error", "Home");

            }          

        }

        // POST: VehicleMakes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        //[HttpDelete]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try { 
            var vehicleMake = await _carService.DeleteVehicleMakeAsync(id);
                return RedirectToAction(nameof(Index));
            }
            catch(Exception)
            {
                return RedirectToAction("Error", "Home");
            }

            
        }




    }
}
