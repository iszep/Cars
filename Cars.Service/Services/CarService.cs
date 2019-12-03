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

        public async Task<IPagingList<VehicleMakeDto>> GetVehicleMakesPagedAsync(VehicleMakeDtoQuery queryParams)
        {
            var query = _db.VehicleMakes.ProjectTo<VehicleMakeDto>(_cfg);
            if (!string.IsNullOrEmpty(queryParams.Search))
            {
                query = query.Where(x => x.Name.Contains(queryParams.Search));
            }
            var model = await PagingList.CreateAsync(query, queryParams.PageSize, queryParams.PageIndex, queryParams.Sort, queryParams.Sort);
            return model;
        }

        public async Task<VehicleMakeDto> GetVehicleMakeAsync(int? id)
        {
            var vehicleMake = await _db.VehicleMakes
               .FirstOrDefaultAsync(m => m.Id == id);
            if (vehicleMake == null)
            {
                throw new Exception("Vehicle Make not found");
            }

            var vehicleMakeDto = _mapper.Map<VehicleMake, VehicleMakeDto>(vehicleMake);

            return vehicleMakeDto;
        }

        public async Task<int> CreateVehicleMakeAsync (VehicleMakeDto vehicleMakeDto)
        {

            var vehicleMake = _mapper.Map<VehicleMakeDto, VehicleMake>(vehicleMakeDto);
            _db.Add(vehicleMake);
            var numberOfCreated = await _db.SaveChangesAsync();            
            return numberOfCreated;
            
        }
           

        public async Task<int> UpdateVehicleMakeAsync(VehicleMakeDto vehicleMakeDto)
        {
            var vehicleMake = _mapper.Map<VehicleMakeDto, VehicleMake>(vehicleMakeDto);
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
        public async Task<IEnumerable<VehicleModelDto>> GetVehicleModelAsync(int makeId)
        {
            
            var vehicleModel = await _db.VehicleModels.Where(x => x.MakeId == makeId).ToListAsync();
            if (vehicleModel == null)
            {
                throw new Exception("Not found");
            }
            var vehicleModelDto = _mapper.Map<IEnumerable<VehicleModel>, IEnumerable<VehicleModelDto>>(vehicleModel);

            return vehicleModelDto;

        }

        public async Task<VehicleModelDto> GetVehicleModelAsync(int? id)
        {
            var vehicleModel = await _db.VehicleModels
               .Include(v => v.VehicleMake)
               .FirstOrDefaultAsync(m => m.Id == id);
            if (vehicleModel == null)
            {
                throw new Exception("Not found");
            }
            var vehicleModelDto = _mapper.Map<VehicleModel, VehicleModelDto>(vehicleModel);
            return vehicleModelDto;
        }

        public async Task<int> CreateVehicleModelAsync(VehicleModelDto vehicleModelDto)
        {
            var vehicleModel = _mapper.Map<VehicleModelDto, VehicleModel>(vehicleModelDto);
            _db.Add(vehicleModel);
            var numberOfCreated = await _db.SaveChangesAsync();            
            return numberOfCreated;
        }

        //public async Task<VehicleModelDto> FindVehicleModelAsync(int? id)
        //{
        //    var vehicleModel = await _db.VehicleModels.FindAsync(id);
        //    var vehicleModelDto = _mapper.Map<VehicleModel, VehicleModelDto>(vehicleModel);
        //    return vehicleModelDto;
        //}

        public async Task<int> UpdateVehicleModelAsync(VehicleModelDto vehicleModelDto)
        {
            var vehicleModel = _mapper.Map<VehicleModelDto, VehicleModel>(vehicleModelDto);
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

        public async Task<IEnumerable<VehicleModelDto>> GetVehicleModelsAsync(int makeId)
        {
            var vehicleModels = await _db.VehicleModels.Where(x => x.MakeId == makeId).Include(v => v.VehicleMake).ToListAsync();
            var vehicleModelDto = _mapper.Map<IEnumerable<VehicleModel>, IEnumerable<VehicleModelDto>>(vehicleModels);
            return vehicleModelDto;
        }

        public bool VehicleModelExists(int? id)
        {
            return _db.VehicleModels.Any(e => e.Id == id);
        }
     

       
    }
}
