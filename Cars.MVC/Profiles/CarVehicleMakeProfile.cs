using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cars.Service.Dtos;
using Cars.Service.Models;
using AutoMapper;

namespace Cars.MVC.Profiles
{
    public class CarVehicleMakeProfile : Profile
    {
        public CarVehicleMakeProfile()
        {
            CreateMap<VehicleMake, VehicleMakeDto>();
            CreateMap<VehicleMakeDto, VehicleMake>();
        }
    }
}
