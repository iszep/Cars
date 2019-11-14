using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cars.Models;

namespace Cars.Interfaces
{
    public interface ICarService
    {
        Task<IEnumerable<VehicleMake>> GetVehicleMakes();
        Task<VehicleMake> VehicleMakeDetail(int? id);
        Task<int> VehicleMakeCreate(VehicleMake vehicleMake);
        Task<VehicleMake> VehicleMakeFind(int? id);
        Task<int> VehicleMakeUpdate(VehicleMake vehicleMake);
        bool VehicleMakeExists(int id);
        Task<int> VehicleMakeDelete(int? id);
    }
}
