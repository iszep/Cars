using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Cars.Service.Models;
using Cars.Service.Dtos;

namespace Cars.MVC.Profiles
{
    public class CarVehicleModelProfile : Profile
    {
        public CarVehicleModelProfile()
        {
            CreateMap<VehicleModel, VehicleModelDto>();
            CreateMap<VehicleModelDto, VehicleModel>();
        }
    }
}
