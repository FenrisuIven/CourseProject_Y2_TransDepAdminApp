using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using AutoMapper;
using TransDep_AdminApp.Enums;
using TransDep_AdminApp.Model;
using TransDep_AdminApp.Model.Trucks;
using TransDep_AdminApp.ViewModel.DTO;

namespace TransDep_AdminApp.ViewModel
{
    public class ObjectMapper
    {
        public static Mapper AutoMapper => new Mapper(GetMapperConfig());    //TODO: Rename AutoMapper to smth
        public static MapperConfiguration GetMapperConfig()
        {
            return new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Tent, TentDTO>();
                cfg.CreateMap<Container, ContainerDTO>();
                cfg.CreateMap<Refrigerated, RefrigeratedDTO>();
                cfg.CreateMap<AutomaticClutch, AutoClutchDTO>();

                cfg.CreateMap<TruckDTO, Refrigerated>()
                    .ConstructUsing(dto => new Refrigerated(dto.Id, dto.DriverID, dto.Name, dto.CarryingCapacity, dto.UsefulVolume, dto.Capacity, dto.ParkingSpot, dto.Availability));
                cfg.CreateMap<TruckDTO, AutomaticClutch>()
                    .ConstructUsing(dto => new AutomaticClutch(dto.Id, dto.DriverID, dto.Name, dto.CarryingCapacity, dto.UsefulVolume, dto.Capacity, dto.ParkingSpot, dto.Availability));
                cfg.CreateMap<TruckDTO, Container>()
                    .ConstructUsing(dto => new Container(dto.Id, dto.DriverID, dto.Name, dto.CarryingCapacity, dto.UsefulVolume, dto.Capacity, dto.ParkingSpot, dto.Availability));
                cfg.CreateMap<TruckDTO, Tent>()
                    .ConstructUsing(dto => new Tent(dto.Id, dto.DriverID, dto.Name, dto.CarryingCapacity, dto.UsefulVolume, dto.Capacity, dto.ParkingSpot, dto.Availability));
                
                cfg.CreateMap<Cargo, CargoDTO>().ReverseMap();
                cfg.CreateMap<Driver, DriverDTO>()
                    .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => $"{src.FirstName},{src.MiddleName},{src.LastName}")).ReverseMap();
                cfg.CreateMap<Route, RouteDTO>().ReverseMap();
                
                cfg.CreateMap<Task, TaskDTO>()
                    .ForMember(dest => dest.TruckExecutor, opt => opt.MapFrom(src => src.TruckExecutor))
                    .ForMember(dest => dest.DriverExecutor, opt => opt.MapFrom(src => src.DriverExecutor))
                    .ForMember(dest => dest.Route, opt => opt.MapFrom(src => src.Route))
                    .ForMember(dest => dest.Cargo, opt => opt.MapFrom(src => src.Cargo));
                
                cfg.CreateMap<TaskDTO, Task>().ConstructUsing(dto => new Task(dto.Name, dto.TruckExecutor, dto.DriverExecutor, dto.Route, dto.Cargo));
            });
        }
        
    }

}