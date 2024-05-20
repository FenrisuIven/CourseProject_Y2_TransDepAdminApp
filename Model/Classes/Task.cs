using TransDep_AdminApp.ViewModel;
using TransDep_AdminApp.ViewModel.DTO;

namespace TransDep_AdminApp.Model
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
            TruckExecutor = truck is TruckDTO ? ObjectMapper.AutoMapper.Map<Truck>(truck) : truck as Truck;
            DriverExecutor = driver is DriverDTO ? ObjectMapper.AutoMapper.Map<Driver>(driver) : driver as Driver;
            Route = route is RouteDTO ? ObjectMapper.AutoMapper.Map<Route>(route) : route as Route;
            Cargo = cargo is CargoDTO  ? ObjectMapper.AutoMapper.Map<Cargo>(cargo) : cargo as Cargo;
        }
        
        public override string ToString() => $"{Name} ({DriverExecutor}; {TruckExecutor.Name}): {Route} | {Cargo}";

    }
}   