using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Cars.Service.Interfaces;

namespace Cars.Service.Models
{
    public class VehicleMake : IVehicleMake
    {
        public VehicleMake()
        {
            VehicleModels = new HashSet<VehicleModel>();
        }
        public int Id { get; set; }
        [Required(ErrorMessage = "Unesite naziv!")]
        [Display(Name="Naziv")]
        public string Name { get; set; }
        [Required]
        public string Abrv { get; set; }
        public ICollection<VehicleModel> VehicleModels {get; set;}
    }
}
