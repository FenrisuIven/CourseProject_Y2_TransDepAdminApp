using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using TransDep_AdminApp.Enums;
using TransDep_AdminApp.Trucks;

namespace TransDep_AdminApp
{
    
    public class ObjectMapper
    {
        public static Mapper AutoMapper => new Mapper(GetMapperConfig());    //TODO: Rename GetMapper to smth
        public static MapperConfiguration GetMapperConfig()
        {
            return new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Refrigerated, TruckDTO>()
                    .ForMember(dest => dest.Type, opt => opt.MapFrom(src => TruckType.Refrigerated)).ReverseMap();
                cfg.CreateMap<AutomaticClutch, TruckDTO>()
                    .ForMember(dest => dest.Type, opt => opt.MapFrom(src => TruckType.AutoClutch)).ReverseMap();
                cfg.CreateMap<Container, TruckDTO>()
                    .ForMember(dest => dest.Type, opt => opt.MapFrom(src => TruckType.Container)).ReverseMap();
                cfg.CreateMap<Tent, TruckDTO>()
                    .ForMember(dest => dest.Type, opt => opt.MapFrom(src => TruckType.Tent)).ReverseMap();
                
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

        public static T Map<T>(object obj) => AutoMapper.Map<T>(obj);
        
        public static object MapToTruckSub(TruckDTO dto)
        {
            switch (dto.Type)
            {
                case TruckType.Refrigerated:
                    return Map<Refrigerated>(dto);
                
                case TruckType.Container:
                    return Map<Container>(dto);
                
                case TruckType.AutoClutch:
                    return Map<AutomaticClutch>(dto);
                
                case TruckType.Tent:
                    return Map<Tent>(dto);
            }
            return default;
        }
        
    }

}