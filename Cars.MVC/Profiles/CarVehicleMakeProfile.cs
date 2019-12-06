using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cars.Service.Dtos;
using Cars.Service.Models;
using AutoMapper;
using Cars.MVC.Models;

namespace Cars.MVC.Profiles
{
    public class CarVehicleMakeProfile : Profile
    {
        public CarVehicleMakeProfile()
        {

            CreateMap<VehicleMake, CreateVehicleMake>();
            CreateMap<CreateVehicleMake, VehicleMake>();

            CreateMap<VehicleMake, DetailsVehicleMake>();
            CreateMap<DetailsVehicleMake, VehicleMake>();

            CreateMap<VehicleMake, DeleteVehicleMake>();
            CreateMap<DeleteVehicleMake, VehicleMake>();

            CreateMap<VehicleMake, EditVehicleMake>();
            CreateMap<EditVehicleMake, VehicleMake>();

            CreateMap<VehicleMake, IndexVehicleMake>();
            CreateMap<IndexVehicleMake, VehicleMake>();
        }
    }
}
