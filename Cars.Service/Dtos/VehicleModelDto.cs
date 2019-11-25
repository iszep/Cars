using System;
using System.Collections.Generic;
using System.Text;
using Cars.Service.Models;

namespace Cars.Service.Dtos
{
   public class VehicleModelDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Abrv { get; set; }
        public int MakeId { get; set; }
        
    }
}
