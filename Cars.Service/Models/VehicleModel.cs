using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Cars.Service.Interfaces;

namespace Cars.Service.Models
{
    public class VehicleModel : IVehicleModel
    {
        public int Id { get; set; }
        
        [Required]
        public string Name { get; set; }
        [Required]
        public string Abrv { get; set; }
        public int MakeId { get; set; }
        [ForeignKey("MakeId")]
        public VehicleMake VehicleMake { get; set; }
    }
}
