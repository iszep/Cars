using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Cars.Service.Data;
using Cars.Service.Dtos;
using Cars.Service.Interfaces;
using Cars.Service.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReflectionIT.Mvc.Paging;

namespace Cars.Service.Services
{
    public class CarService : ICarService
    {
        ApplicationDbContext _db;
        IMapper _mapper;
        IConfigurationProvider _cfg;
        public CarService(ApplicationDbContext db, IMapper mapper, IConfigurationProvider cfg)
        {
            _db = db;
            _mapper = mapper;
            _cfg = cfg;
        }

        public IQueryable<VehicleMake> GetVehicleMakesPaged(IVehicleMakeQuery queryParams)
        {
            var query = _db.VehicleMakes.AsQueryable();
            if (!string.IsNullOrEmpty(queryParams.Search))
            {
                query = query.Where(x => x.Name.Contains(queryParams.Search));
            }
            return query;
        }

        public async Task<VehicleMake> GetVehicleMakeAsync(int? id)
        {
            var vehicleMake = await _db.VehicleMakes
               .FirstOrDefaultAsync(m => m.Id == id);
            if (vehicleMake == null)
            {
                throw new Exception("Vehicle Make not found");
            }           

            return vehicleMake;
        }

        public async Task<int> CreateVehicleMakeAsync (VehicleMake vehicleMake)
        {

            _db.Add(vehicleMake);
            var numberOfCreated = await _db.SaveChangesAsync();            
            return numberOfCreated;
            
        }
           

        public async Task<int> UpdateVehicleMakeAsync(VehicleMake vehicleMake)
        {
            
            _db.Update(vehicleMake);
            var numberOfChanges = await _db.SaveChangesAsync();
            
            return numberOfChanges;
        }

        public bool VehicleMakeExists(int id)
        {
            return _db.VehicleMakes.Any(e => e.Id == id);
        }

        public async Task<int> DeleteVehicleMakeAsync(int? id)
        {
            var vehicleMake = await _db.VehicleMakes.FirstOrDefaultAsync(x => x.Id == id);
            if (vehicleMake == null)
            {
                throw new Exception("Not found");
            }

            _db.VehicleMakes.Remove(vehicleMake);
            var numberOfDeleted = await _db.SaveChangesAsync();
            return numberOfDeleted;
            
        }
        public async Task<IEnumerable<VehicleModel>> GetVehicleModelAsync(int makeId)
        {
            
            var vehicleModel = await _db.VehicleModels.Where(x => x.MakeId == makeId).ToListAsync();
            if (vehicleModel == null)
            {
                throw new Exception("Not found");
            }
           
            return vehicleModel;

        }

        public async Task<VehicleModel> GetVehicleModelAsync(int? id)
        {
            var vehicleModel = await _db.VehicleModels
               .Include(v => v.VehicleMake)
               .FirstOrDefaultAsync(m => m.Id == id);
            if (vehicleModel == null)
            {
                throw new Exception("Not found");
            }
            
            return vehicleModel;
        }

        public async Task<int> CreateVehicleModelAsync(VehicleModel vehicleModel)
        {
            
            _db.Add(vehicleModel);
            var numberOfCreated = await _db.SaveChangesAsync();            
            return numberOfCreated;
        }
      

        public async Task<int> UpdateVehicleModelAsync(VehicleModel vehicleModel)
        {
            
            _db.Update(vehicleModel);
           var numberOfChanges = await _db.SaveChangesAsync();
            return numberOfChanges;
        }

        public async Task<int> DeleteVehicleModelAsync(int? id)
        {
            var vehicleModel = await _db.VehicleModels.FindAsync(id);
            _db.VehicleModels.Remove(vehicleModel);
            var numberOfDeleted = await _db.SaveChangesAsync();
            return numberOfDeleted;
        }
 

        public bool VehicleModelExists(int? id)
        {
            return _db.VehicleModels.Any(e => e.Id == id);
        }
     

       
    }
}
