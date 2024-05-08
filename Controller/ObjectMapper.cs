using System;
using System.Collections.Generic;
using AutoMapper;
using TransDep_AdminApp.Trucks;

namespace TransDep_AdminApp
{
    
    public class ObjectMapper
    {
        public static Mapper GetMapper => new Mapper(GetMapperConfig());    //TODO: Rename GetMapper to smth
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
                
                cfg.CreateMap<TaskDTO, Task>().ConstructUsing(x => MapToTask(x));
            });
        }

        public static T MapTo<T>(object obj) => GetMapper.Map<T>(obj);
        public static TaskDTO Map(Task obj)
        {
            return new TaskDTO
            {
                Name = obj.Name,
                TruckExecutor = MapTo<TruckDTO>(obj.TruckExecutor),
                DriverExecutor = MapTo<DriverDTO>(obj.DriverExecutor),
                Route = MapTo<RouteDTO>(obj.Route),
                Cargo = MapTo<CargoDTO>(obj.Cargo)
            };
        }
        //TODO: Seems to not be working. Need to be fixed
        public static Func<TaskDTO, Task> MapToTask = (obj) => new Task(
            obj.Name,
            (Truck)MapToTruckSub(obj.TruckExecutor),
            MapTo<Driver>(obj.DriverExecutor),
            MapTo<Route>(obj.Route),
            MapTo<Cargo>(obj.Cargo));
        
        //TODO: -----------------------------------------
        public static object MapToTruckSub(TruckDTO dto)
        {
            switch (dto.Type)
            {
                case TruckType.Refrigerated:
                    return MapTo<Refrigerated>(dto);
                
                case TruckType.Container:
                    return MapTo<Container>(dto);
                
                case TruckType.AutoClutch:
                    return MapTo<AutomaticClutch>(dto);
                
                case TruckType.Tent:
                    return MapTo<Tent>(dto);
            }
            return default;
        }
        
    }

}