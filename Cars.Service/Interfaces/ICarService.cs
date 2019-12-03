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
        Task<IPagingList<VehicleMakeDto>> GetVehicleMakesPagedAsync(VehicleMakeDtoQuery queryParams);
        Task<VehicleMakeDto> GetVehicleMakeAsync(int? id);
        Task<int> CreateVehicleMakeAsync(VehicleMakeDto vehicleMakeDto);
        //Task<VehicleMakeDto> FindVehicleMakeAsync(int? id);
        Task<int> UpdateVehicleMakeAsync(VehicleMakeDto vehicleMakeDto);
        bool VehicleMakeExists(int id);
        Task<int> DeleteVehicleMakeAsync(int? id);

        // Car Models
        Task<IEnumerable<VehicleModelDto>> GetVehicleModelAsync(int makeId);
        Task<VehicleModelDto> GetVehicleModelAsync(int? id);
        Task<int> CreateVehicleModelAsync(VehicleModelDto vehicleModelDto);
        //Task<VehicleModelDto> FindVehicleModelAsync(int? id);
        Task<int> UpdateVehicleModelAsync(VehicleModelDto vehicleModelDto);
        Task<int> DeleteVehicleModelAsync(int? id);
        bool VehicleModelExists(int? id);

    }
}
