using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cars.Service.Dtos;
using Cars.Service.Models;


namespace Cars.Service.Interfaces
{
    public interface ICarService
    {
        // Car Makes
        //Task<IEnumerable<VehicleMake>> GetVehicleMakeAsync();
        Task<IEnumerable<VehicleMakeDto>> GetVehicleMakesPagedAsync(int page, int pageSize, string searchString);
        Task<int> GetVehicleMakesCount();     
        Task<VehicleMakeDto> GetVehicleMakeAsync(int? id);
        Task<int> CreateVehicleMakeAsync(VehicleMakeDto vehicleMakeDto);
        Task<VehicleMakeDto> FindVehicleMakeAsync(int? id);
        Task<int> UpdateVehicleMakeAsync(VehicleMakeDto vehicleMakeDto);
        bool VehicleMakeExists(int id);
        Task<int> DeleteVehicleMakeAsync(int? id);

        // Car Models
        Task<IEnumerable<VehicleModelDto>> GetVehicleModelAsync(int makeId);
        Task<VehicleModelDto> GetVehicleModelAsync(int? id);
        Task<int> CreateVehicleModelAsync(VehicleModelDto vehicleModelDto);
        Task<VehicleModelDto> FindVehicleModelAsync(int? id);
        Task<int> UpdateVehicleModelAsync(VehicleModelDto vehicleModelDto);
        Task<int> DeleteVehicleModelAsync(int? id);
        bool VehicleModelExists(int? id);

    }
}
