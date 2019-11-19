using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cars.Service.Data;
using Cars.Service.Interfaces;
using Cars.Service.Models;
using Microsoft.EntityFrameworkCore;

namespace Cars.Service.Services
{
    public class CarService : ICarService
    {
        ApplicationDbContext _db;
        public CarService(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<IEnumerable<VehicleMake>> GetVehicleMakeAsync()
        {
            var vehicleMakes = await _db.VehicleMakes.ToListAsync();
            return vehicleMakes;
        }

        public async Task<VehicleMake> GetVehicleMakeAsync(int? id)
        {
            var vehicleMake = await _db.VehicleMakes
               .FirstOrDefaultAsync(m => m.Id == id);
            return vehicleMake;
        }

        public async Task<int> CreateVehicleMakeAsync (VehicleMake vehicleMake)
        {
            _db.Add(vehicleMake);
            var numberOfCreated = await _db.SaveChangesAsync();
            return numberOfCreated;
            
        }

        public async Task<VehicleMake> FindVehicleMakeAsync(int? id)
        {
            var vehicleMake = await _db.VehicleMakes.FindAsync(id);
            return vehicleMake;
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
            var vehicleMake = await _db.VehicleMakes.FindAsync(id);
            _db.VehicleMakes.Remove(vehicleMake);
            var numberOfDeleted = await _db.SaveChangesAsync();
            return numberOfDeleted;
            
        }

    }
}
