using TransDep_AdminApp.ViewModel;
using TransDep_AdminApp.ViewModel.DTO;

namespace TransDep_AdminApp.Model
{
    public class Task
    {
        public string Name { get; private set; }
        public string TruckExecutorID { get; private set; }
        public string DriverExecutorID { get; private set; }
        public Route Route { get; private set; }
        public Cargo Cargo { get; private set; }
        
        public Task(string name, object truck, object driver, object route, object cargo)
        {
            Name = name;
            TruckExecutorID = truck is TruckDTO ? ((TruckDTO)truck).Id : ((Truck)truck).Id;
            DriverExecutorID = driver is DriverDTO ? ((DriverDTO)driver).Id : ((Driver)driver).Id;
            Route = route is RouteDTO ? ObjectMapper.AutoMapper.Map<Route>(route) : route as Route;
            Cargo = cargo is CargoDTO  ? ObjectMapper.AutoMapper.Map<Cargo>(cargo) : cargo as Cargo;
        }
        public Task(string name, string truck, string driver, object route, object cargo)
        {
            Name = name;
            TruckExecutorID = truck;
            DriverExecutorID = driver;
            Route = route is RouteDTO ? ObjectMapper.AutoMapper.Map<Route>(route) : route as Route;
            Cargo = cargo is CargoDTO  ? ObjectMapper.AutoMapper.Map<Cargo>(cargo) : cargo as Cargo;
        }
        public override string ToString() => $"{Name} (Driver: {DriverExecutorID}; Truck: {TruckExecutorID}): {Route} | {Cargo}";

    }
}   