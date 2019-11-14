using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cars.Data;
using Cars.Interfaces;
using Cars.Models;
using Microsoft.EntityFrameworkCore;

namespace Cars.Services
{
    public class CarService : ICarService
    {
        ApplicationDbContext _db;
        public CarService(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<IEnumerable<VehicleMake>> GetVehicleMakes()
        {
            var vehicleMakes = await _db.VehicleMakes.ToListAsync();
            return vehicleMakes;
        }

        public async Task<VehicleMake> VehicleMakeDetail(int? id)
        {
            var vehicleMake = await _db.VehicleMakes
               .FirstOrDefaultAsync(m => m.Id == id);
            return vehicleMake;
        }

        public async Task<int> VehicleMakeCreate (VehicleMake vehicleMake)
        {
            _db.Add(vehicleMake);
            var numberOfCreated = await _db.SaveChangesAsync();
            return numberOfCreated;
            
        }

        public async Task<VehicleMake> VehicleMakeFind(int? id)
        {
            var vehicleMake = await _db.VehicleMakes.FindAsync(id);
            return vehicleMake;
        }
        public async Task<int> VehicleMakeUpdate(VehicleMake vehicleMake)
        {
            _db.Update(vehicleMake);
            var numberOfChanges = await _db.SaveChangesAsync();
            return numberOfChanges;
        }

        public bool VehicleMakeExists(int id)
        {
            return _db.VehicleMakes.Any(e => e.Id == id);
        }

        public async Task<int> VehicleMakeDelete(int? id)
        {
            var vehicleMake = await _db.VehicleMakes.FindAsync(id);
            _db.VehicleMakes.Remove(vehicleMake);
            var numberOfDeleted = await _db.SaveChangesAsync();
            return numberOfDeleted;
            
        }

    }
}
