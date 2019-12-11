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
using Cars.MVC.Models;

namespace Cars.Controllers
{
    public class VehicleModelController : Controller
    {
         private readonly IVehicleModelService _vehicleModelService; IMapper _mapper;

        public VehicleModelController(IVehicleModelService vehicleModelService, IMapper mapper)
        {           
            _vehicleModelService = vehicleModelService;
            _mapper = mapper;
        }

        // GET: VehicleModels
        public async Task<IActionResult> Index(int makeId)
        {

            ViewBag.MakeId = makeId;
            var vehicleModel = await _vehicleModelService.GetVehicleModelAsync(makeId);
            var indexVehicleModel = _mapper.Map<IEnumerable<VehicleModel>, IEnumerable<IndexVehicleModel>>(vehicleModel);

            return View(indexVehicleModel);
            
        }

        // GET: VehicleModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            try
            {
                var vehicleModel = await _vehicleModelService.GetVehicleModelAsync(id);
                var detailsVehicleModel = _mapper.Map<VehicleModel, DetailsVehicleModel>(vehicleModel);
                return View(detailsVehicleModel);
            }
            catch(Exception)
            {
                return RedirectToAction("Error", "Home");
            }
                     
          
        }

        // GET: VehicleModels/Create
        public IActionResult Create(int makeId)
        {
            
            var vehicleModel = new VehicleModel { MakeId = makeId };
            var createVehicleModel = _mapper.Map<VehicleModel, CreateVehicleModel>(vehicleModel);
            return View(createVehicleModel);
        }

        // POST: VehicleModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Abrv,MakeId")] CreateVehicleModel createVehicleModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var vehicleModel = _mapper.Map<CreateVehicleModel, VehicleModel>(createVehicleModel);
                    var numberOfSaves = await _vehicleModelService.CreateVehicleModelAsync(vehicleModel);                
                return RedirectToAction(nameof(Index), new { makeId = vehicleModel.MakeId });
                }
                catch (Exception)
                {
                    return RedirectToAction("Error", "Home");
                }
            }
           
            return View(createVehicleModel);
        }

        // GET: VehicleModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            
            if (id == null)
            {
                return NotFound();
            }

            try
            { 
           
            var vehicleModel = await _vehicleModelService.GetVehicleModelAsync(id);
            var editVehicleModel = _mapper.Map<VehicleModel, EditVehicleModel>(vehicleModel);
            var vehicleMake = await _vehicleModelService.GetVehicleMakeAsync(vehicleModel.MakeId);
            ViewBag.VehicleMakeName = vehicleMake.Name;
                return View(editVehicleModel);

            }
            catch(Exception)
            {
                return RedirectToAction("Error", "Home");
            }
                     
            
           
        }

        // POST: VehicleModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Abrv,MakeId")] EditVehicleModel editVehicleModel)
        {
            
            if (id != editVehicleModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var vehicleModel = _mapper.Map<EditVehicleModel, VehicleModel>(editVehicleModel);
                    await _vehicleModelService.UpdateVehicleModelAsync(vehicleModel);                   
                    
                }
                catch (Exception)
                {
                    return RedirectToAction("Error", "Home");
                }
                return RedirectToAction(nameof(Index), new { makeId = editVehicleModel.MakeId });
            }
            return View(editVehicleModel);
            
        }

        // GET: VehicleModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            try
            {
                var vehicleModel = await _vehicleModelService.GetVehicleModelAsync(id);
                var deleteVehicleModel = _mapper.Map<VehicleModel, DeleteVehicleModel>(vehicleModel);
                return View(deleteVehicleModel);
            }

                   catch(Exception)
            {
                return RedirectToAction("Error", "Home");
            }               
           
        }

        // POST: VehicleModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id, [Bind("Id,Name,Abrv,MakeId")] VehicleModel vehicleModel)
        {
            
            try
            {
                await _vehicleModelService.DeleteVehicleModelAsync(id);                

                return RedirectToAction(nameof(Index), new { makeId = vehicleModel.MakeId });

            }
                 
            catch (Exception)
            {
                return RedirectToAction("Error", "Home");
            }
        }

        private bool VehicleModelExists(int id)
        {
            _vehicleModelService.VehicleModelExists(id);
            return true;
        }

       
    }
}
