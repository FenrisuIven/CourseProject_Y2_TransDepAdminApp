using AutoMapper.Internal;
using mapper = TransDep_AdminApp.ObjectMapper;

namespace TransDep_AdminApp
{
    public class Task
    {
        public string Name { get; private set; }
        public Truck TruckExecutor { get; private set; }
        public Driver DriverExecutor { get; private set; }
        public Route Route { get; private set; }
        public Cargo Cargo { get; private set; }
        
        public Task(string name, object truck, object driver, object route, object cargo)
        {
            Name = name;
            TruckExecutor = truck is TruckDTO truckDto ? (Truck)mapper.MapToTruckSub(truckDto) : truck as Truck;
            DriverExecutor = driver is DriverDTO driverDto ? mapper.Map<Driver>(driverDto) : driver as Driver;
            Route = route is RouteDTO routeDto ? mapper.Map<Route>(routeDto) : route as Route;
            Cargo = cargo is CargoDTO cargoDto ? mapper.Map<Cargo>(cargoDto) : cargo as Cargo;
        }
        
        public override string ToString() => $"{Name} ({DriverExecutor}; {TruckExecutor.Name}): {Route} | {Cargo}";

    }
}   