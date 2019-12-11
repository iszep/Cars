using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Cars.Service.Data;
using Cars.Service.Dtos;
using Cars.Service.Interfaces;
using Cars.Service.Models;
using Microsoft.EntityFrameworkCore;

namespace Cars.Service.Services
{
   public class VehicleMakeService : IVehicleMakeService
    {
        ApplicationDbContext _db;
        IMapper _mapper;
        IConfigurationProvider _cfg;
        public VehicleMakeService(ApplicationDbContext db, IMapper mapper, IConfigurationProvider cfg)
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

            //if (!string.IsNullOrEmpty(queryParams.Sort))
            //{
            //    query = query.OrderBy(x => x.Name.Contains(queryParams.Search));
            //}

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

        public async Task<int> CreateVehicleMakeAsync(VehicleMake vehicleMake)
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
    }
}
