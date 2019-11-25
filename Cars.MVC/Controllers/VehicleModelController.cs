using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Cars.Service.Data;
using Cars.Service.Models;
using Cars.Service.Interfaces;
using AutoMapper;
using Cars.Service.Dtos;

namespace Cars.Controllers
{
    public class VehicleModelController : Controller
    {
         private readonly ICarService _carService; IMapper _mapper;

        public VehicleModelController(ICarService carService, IMapper mapper)
        {           
            _carService = carService;
            _mapper = mapper;
        }

        // GET: VehicleModels
        public async Task<IActionResult> Index(int makeId)
        {

            ViewBag.MakeId = makeId;
            var vehicleModel = await _carService.GetVehicleModelAsync(makeId);

            return View(vehicleModel);
            
        }

        // GET: VehicleModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehicleModel = await _carService.GetVehicleModelAsync(id);
            if (vehicleModel == null)
            {
                return NotFound();
            }

            return View(vehicleModel);
        }

        // GET: VehicleModels/Create
        public IActionResult Create(int makeId)
        {
            
            var vehicleModel = new VehicleModelDto { MakeId = makeId };
            return View(vehicleModel);
        }

        // POST: VehicleModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Abrv,MakeId")] VehicleModelDto vehicleModelDto)
        {
            if (ModelState.IsValid)
            {
                var numberOfSaves = await _carService.CreateVehicleModelAsync(vehicleModelDto);                
                return RedirectToAction(nameof(Index), new { makeId = vehicleModelDto.MakeId });
            }
            //ViewData["MakeId"] = new SelectList(_context.VehicleMakes, "Id", "Abrv", vehicleModel.MakeId);
            return View(vehicleModelDto);
        }

        // GET: VehicleModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            
            if (id == null)
            {
                return NotFound();
            }

            
           
            var vehicleModel = await _carService.FindVehicleModelAsync(id);
            var vehicleMake = await _carService.FindVehicleMakeAsync(vehicleModel.MakeId);
            ViewBag.VehicleMakeName = vehicleMake.Name;


            if (vehicleModel == null)
            {
                return NotFound();
            }            
            
            return View(vehicleModel);
        }

        // POST: VehicleModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Abrv,MakeId")] VehicleModelDto vehicleModelDto)
        {
            
            if (id != vehicleModelDto.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    
                    await _carService.UpdateVehicleModelAsync(vehicleModelDto);
                    
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VehicleModelExists(vehicleModelDto.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index), new { makeId = vehicleModelDto.MakeId });

            }
            //var vehicleMake = await _carService.GetVehicleMakeAsync();
            
            return View(vehicleModelDto);
            
        }

        // GET: VehicleModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehicleModel = await _carService.FindVehicleModelAsync(id);                
                
            if (vehicleModel == null)
            {
                return NotFound();
            }

            return View(vehicleModel);
        }

        // POST: VehicleModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id, [Bind("Id,Name,Abrv,MakeId")] VehicleModelDto vehicleModelDto)
        {
            
            
                 await _carService.DeleteVehicleModelAsync(id);

               return RedirectToAction(nameof(Index), new { makeId = vehicleModelDto.MakeId});

        }

        private bool VehicleModelExists(int id)
        {
            _carService.VehicleModelExists(id);
            return true;
        }

       
    }
}
