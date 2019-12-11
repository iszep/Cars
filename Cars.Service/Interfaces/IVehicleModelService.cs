using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Cars.Service.Models;

namespace Cars.Service.Interfaces
{
    public interface IVehicleModelService
    {
        Task<IEnumerable<VehicleModel>> GetVehicleModelAsync(int makeId);
        Task<VehicleModel> GetVehicleModelAsync(int? id);
        Task<int> CreateVehicleModelAsync(VehicleModel vehicleModel);

        Task<int> UpdateVehicleModelAsync(VehicleModel vehicleModel);
        Task<int> DeleteVehicleModelAsync(int? id);
        Task<VehicleMake> GetVehicleMakeAsync(int? id);
        bool VehicleModelExists(int? id);

    }
}
