﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cars.MVC.Models
{
    public class DeleteVehicleModel
    {
        public string Name { get; set; }
        public string Abrv { get; set; }
        public int MakeId { get; set; }
    }
}
