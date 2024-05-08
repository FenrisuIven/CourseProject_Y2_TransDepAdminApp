namespace TransDep_AdminApp
{
    public class Task
    {
        public string Name { get; private set; }
        public Truck TruckExecutor { get; private set; }
        public Driver DriverExecutor { get; private set; }
        public Route Route { get; private set; }
        public Cargo Cargo { get; private set; }
        
        public Task(string name, Truck truck, Driver driver, Route route, Cargo cargo)
        {
            Name = name;
            TruckExecutor = truck;
            DriverExecutor = driver;
            Route = route;
            Cargo = cargo;
        }

        public override string ToString() => $"{getName()} ({getDriverExecutor()}; {getTruckExecutor()}): {getTaskRoute()} | {getCargo()}";

        public string getName() => $"{Name}";
        public string getTruckExecutor() => $"{TruckExecutor.stringName()}";
        public string getDriverExecutor() => $"{DriverExecutor}";
        public string getTaskRoute() => $"{Route.GetRoute()}; {Route.GetTime()}";
        public string getCargo() => $"{Cargo.TypeToString()}; {Cargo.WeightToString()}; {Cargo.VolumeToString()};";
    }
}   