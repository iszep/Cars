using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cars.Interfaces;
using Cars.Models;

namespace Cars.Services
{
    public class FakeCarService : ICarService
    {
        public Task<IEnumerable<VehicleMake>> GetVehicleMakes()
        {
            var vehicleMakes = new List<VehicleMake>();
            vehicleMakes.Add(new VehicleMake { Name = "Test auto", Abrv = "TEST" });
            return Task.FromResult<IEnumerable<VehicleMake>>(vehicleMakes);
        }

        public Task<int> VehicleMakeCreate(VehicleMake vehicleMake)
        {
            throw new NotImplementedException();
        }

        public Task<int> VehicleMakeDelete(int? id)
        {
            throw new NotImplementedException();
        }

        public Task<VehicleMake> VehicleMakeDetail(int? id)
        {
            throw new NotImplementedException();
        }

        public bool VehicleMakeExists(int id)
        {
            throw new NotImplementedException();
        }

        public Task<VehicleMake> VehicleMakeFind(int? id)
        {
            throw new NotImplementedException();
        }

        public Task<int> VehicleMakeUpdate(VehicleMake vehicleMake)
        {
            throw new NotImplementedException();
        }
    }
}
