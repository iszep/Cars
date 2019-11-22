using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cars.Service.Models;


namespace Cars.Service.Interfaces
{
    public interface ICarService
    {
        // Car Makes
        Task<IEnumerable<VehicleMake>> GetVehicleMakeAsync();
        Task<IEnumerable<VehicleMake>> GetVehicleMakesPagedAsync(int page, int pageSize, string searchString);
        Task<int> GetVehicleMakesCount();     
        Task<VehicleMake> GetVehicleMakeAsync(int? id);
        Task<int> CreateVehicleMakeAsync(VehicleMake vehicleMake);
        Task<VehicleMake> FindVehicleMakeAsync(int? id);
        Task<int> UpdateVehicleMakeAsync(VehicleMake vehicleMake);
        bool VehicleMakeExists(int id);
        Task<int> DeleteVehicleMakeAsync(int? id);

        // Car Models
        Task<IEnumerable<VehicleModel>> GetVehicleModelsAsync(int makeId);
        Task<VehicleModel> GetVehicleModelAsync(int? id);
        Task<int> CreateVehicleModelAsync(VehicleModel vehicleModel);
        Task<VehicleModel> FindVehicleModelAsync(int? id);
        Task<int> UpdateVehicleModelAsync(VehicleModel vehicleModel);
        Task<int> DeleteVehicleModelAsync(int? id);
        bool VehicleModelExists(int? id);

    }
}
