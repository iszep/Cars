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
            
            CreateMap<VehicleModel, CreateVehicleModel>();
            CreateMap<CreateVehicleModel, VehicleModel>();

            CreateMap<VehicleModel, IndexVehicleModel>();
            CreateMap<IndexVehicleModel, VehicleModel>();

            CreateMap<VehicleModel, DetailsVehicleModel>();
            CreateMap<DetailsVehicleModel, VehicleModel>();

            CreateMap<VehicleModel, EditVehicleModel>();
            CreateMap<EditVehicleModel, VehicleModel>();

            CreateMap<VehicleModel, DeleteVehicleModel>();
            CreateMap<DeleteVehicleModel, VehicleModel>();


        }
    }
}
