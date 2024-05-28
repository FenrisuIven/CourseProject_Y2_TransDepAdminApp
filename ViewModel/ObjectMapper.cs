using AutoMapper;
using TransDep_AdminApp.Enums;
using TransDep_AdminApp.Model;
using TransDep_AdminApp.Model.Trucks;
using TransDep_AdminApp.View.Screens;
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
                cfg.CreateMap<Refrigerated, TruckDTO>().ForMember(dest => dest.Type, opt => opt.MapFrom(elem => TruckType.Refrigerated)).ReverseMap();
                cfg.CreateMap<AutomaticClutch, TruckDTO>().ForMember(dest => dest.Type, opt => opt.MapFrom(elem => TruckType.AutoClutch)).ReverseMap();
                cfg.CreateMap<Container, TruckDTO>().ForMember(dest => dest.Type, opt => opt.MapFrom(elem => TruckType.Container)).ReverseMap();
                cfg.CreateMap<Tent, TruckDTO>().ForMember(dest => dest.Type, opt => opt.MapFrom(elem => TruckType.Tent)).ReverseMap();

                cfg.CreateMap<TruckDTO, Truck>().ConvertUsing((dto, obj, ctx) =>
                {
                    switch (dto.Type)
                    {
                        case TruckType.Container:
                            return ctx.Mapper.Map<Container>(dto);
                        case TruckType.Refrigerated:
                            return ctx.Mapper.Map<Refrigerated>(dto);
                        case TruckType.Tent:
                            return ctx.Mapper.Map<Tent>(dto);
                        case TruckType.AutoClutch:
                            return ctx.Mapper.Map<AutomaticClutch>(dto);
                    }

                    return obj;
                });
                
                cfg.CreateMap<Cargo, CargoDTO>().ReverseMap();
                cfg.CreateMap<Driver, DriverDTO>()
                    .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => $"{src.FirstName},{src.MiddleName},{src.LastName}"))
                    .ReverseMap();
                cfg.CreateMap<Route, RouteDTO>().ReverseMap();
                
                cfg.CreateMap<Task, TaskDTO>()
                    .ForMember(dest => dest.TruckExecutorID, opt => opt.MapFrom(src => src.TruckExecutorID))
                    .ForMember(dest => dest.DriverExecutorID, opt => opt.MapFrom(src => src.DriverExecutorID))
                    .ForMember(dest => dest.Route, opt => opt.MapFrom(src => src.Route))
                    .ForMember(dest => dest.Cargo, opt => opt.MapFrom(src => src.Cargo));
                
                cfg.CreateMap<TaskDTO, Task>().ConstructUsing(dto => new Task(dto.Name, dto.TruckExecutorID, dto.DriverExecutorID, dto.Route, dto.Cargo));
            });
        }
        
    }

}