using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Cars.Service.Models;
using Cars.Service.Dtos;
using Cars.MVC.Models;

namespace Cars.MVC.Profiles
{
    public class CarVehicleModelProfile : Profile
    {
        public CarVehicleModelProfile()
        {
            CreateMap<VehicleModel, VehicleModelDto>();
            CreateMap<VehicleModelDto, VehicleModel>();

            CreateMap<VehicleModel, CreateVehicleModel>();
            CreateMap<CreateVehicleModel, VehicleMake>();

            CreateMap<VehicleModel, IndexVehicleModel>();
            CreateMap<IndexVehicleModel, VehicleMake>();
        }
    }
}
