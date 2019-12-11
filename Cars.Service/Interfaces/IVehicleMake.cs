using System;
using System.Collections.Generic;
using System.Text;
using Cars.Service.Models;

namespace Cars.Service.Interfaces
{
    public interface IVehicleMake
    {      
        public int Id { get; set; }        
        public string Name { get; set; }       
        public string Abrv { get; set; }
        public ICollection<VehicleModel> VehicleModels { get; set; }
    }
}
