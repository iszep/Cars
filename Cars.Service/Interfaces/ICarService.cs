using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cars.Service.Dtos;
using Cars.Service.Models;
using ReflectionIT.Mvc.Paging;

namespace Cars.Service.Interfaces
{
    public interface ICarService
    {
        // Car Makes
        IQueryable<VehicleMake> GetVehicleMakesPaged(IVehicleMakeQuery queryParams);
        Task<VehicleMake> GetVehicleMakeAsync(int? id);
        Task<int> CreateVehicleMakeAsync(VehicleMake vehicleMake);
        Task<int> UpdateVehicleMakeAsync(VehicleMake vehicleMake);
        bool VehicleMakeExists(int id);
        Task<int> DeleteVehicleMakeAsync(int? id);

        // Car Models
        Task<IEnumerable<VehicleModel>> GetVehicleModelAsync(int makeId);
        Task<VehicleModelDto> GetVehicleModelAsync(int? id);
        Task<int> CreateVehicleModelAsync(VehicleModel vehicleModel);
       
        Task<int> UpdateVehicleModelAsync(VehicleModelDto vehicleModelDto);
        Task<int> DeleteVehicleModelAsync(int? id);
        bool VehicleModelExists(int? id);

    }
}
