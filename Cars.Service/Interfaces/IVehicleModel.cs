using System;
using System.Collections.Generic;
using System.Text;
using Cars.Service.Models;

namespace Cars.Service.Interfaces
{
    public interface IVehicleModel
    {
        public int Id { get; set; }        
        public string Name { get; set; }
        public string Abrv { get; set; }
        public int MakeId { get; set; }        
        public VehicleMake VehicleMake { get; set; }
    }
}
