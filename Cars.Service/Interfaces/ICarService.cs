using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cars.Service.Models;


namespace Cars.Service.Interfaces
{
    public interface ICarService
    {
        Task<IEnumerable<VehicleMake>> GetVehicleMakeAsync();
        Task<IEnumerable<VehicleMake>> GetVehicleMakesPagedAsync(int page, int pageSize);
        Task<int> GetVehicleMakesCount();     
        Task<VehicleMake> GetVehicleMakeAsync(int? id);
        Task<int> CreateVehicleMakeAsync(VehicleMake vehicleMake);
        Task<VehicleMake> FindVehicleMakeAsync(int? id);
        Task<int> UpdateVehicleMakeAsync(VehicleMake vehicleMake);
        bool VehicleMakeExists(int id);
        Task<int> DeleteVehicleMakeAsync(int? id);
    }
}
