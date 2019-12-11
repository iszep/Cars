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
using Cars.MVC.Models;
using AutoMapper;
using ReflectionIT.Mvc.Paging;
using AutoMapper.QueryableExtensions;

namespace Cars.Controllers
{
    public class VehicleMakeController : Controller
    {

        private readonly IVehicleMakeService _vehicleMakeService;
        private readonly IMapper _mapper;
        private readonly int _pageSize = 5;
        IConfigurationProvider _cfg;

        public VehicleMakeController(IVehicleMakeService vehicleMakeService, IMapper mapper, IConfigurationProvider cfg)
        {

            _vehicleMakeService = vehicleMakeService;
            _mapper = mapper;
            _cfg = cfg;
        }

        public async Task<IActionResult> Index(int pageindex = 1, string sort = "Name", string search = "")
        {
            
            var queryParams = new VehicleMakeQuery { PageIndex = pageindex, Sort = sort, Search = search, PageSize = _pageSize };

            var query = _vehicleMakeService.GetVehicleMakesPaged(queryParams).ProjectTo<IndexVehicleMake>(_cfg);
            var page = await PagingList.CreateAsync(query, queryParams.PageSize, queryParams.PageIndex, queryParams.Sort, queryParams.Sort);

            page.RouteValue = new RouteValueDictionary
            {
                { "search", search }
            };

            return View(page);
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
                
                var vehicleMake = await _vehicleMakeService.GetVehicleMakeAsync(id);
                var detailsVehicleMake = _mapper.Map<VehicleMake, DetailsVehicleMake>(vehicleMake);
                return View(detailsVehicleMake);

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
        public async Task<IActionResult> Create([Bind("Name,Abrv")] CreateVehicleMake createVehicleMake)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var vehicleMake = _mapper.Map<CreateVehicleMake, VehicleMake>(createVehicleMake);
                    var numberOfSaves = await _vehicleMakeService.CreateVehicleMakeAsync(vehicleMake);
                    return RedirectToAction(nameof(Index));
                }
                catch(Exception)
                {
                    return RedirectToAction("Error", "Home");
                }
                

            }
            return View(createVehicleMake);
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
                var vehicleMake = await _vehicleMakeService.GetVehicleMakeAsync(id);
                var editVehicleMake = _mapper.Map<VehicleMake, EditVehicleMake>(vehicleMake);
                return View(editVehicleMake);
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
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Abrv")] EditVehicleMake editVehicleMake)
        {
            if (id != editVehicleMake.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var vehicleMake = _mapper.Map<EditVehicleMake, VehicleMake>(editVehicleMake);
                    var numberOfChanges = await _vehicleMakeService.UpdateVehicleMakeAsync(vehicleMake);
                }
                catch (Exception)
                {
                    return RedirectToAction("Error", "Home");                
                }
                return RedirectToAction(nameof(Index));
            }
            return View(editVehicleMake);
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
                var vehicleMake = await _vehicleMakeService.GetVehicleMakeAsync(id);
                var deleteVehicleMake = _mapper.Map<VehicleMake, DeleteVehicleMake>(vehicleMake);
                return View(deleteVehicleMake);
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
            var vehicleMake = await _vehicleMakeService.DeleteVehicleMakeAsync(id);
                return RedirectToAction(nameof(Index));
            }
            catch(Exception)
            {
                return RedirectToAction("Error", "Home");
            }

            
        }




    }
}
