using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cars.Service.Dtos;
using Cars.Service.Models;

namespace Cars.Service.Interfaces
{
    public interface IVehicleMakeService
    {
        IQueryable<VehicleMake> GetVehicleMakesPaged(IVehicleMakeQuery queryParams);
        Task<VehicleMake> GetVehicleMakeAsync(int? id);
        Task<int> CreateVehicleMakeAsync(VehicleMake vehicleMake);
        Task<int> UpdateVehicleMakeAsync(VehicleMake vehicleMake);
        bool VehicleMakeExists(int id);
        Task<int> DeleteVehicleMakeAsync(int? id);
    }
}
