namespace TransDep_AdminApp
{
    public class Task
    {
        protected string _Name { get; set; }
        protected Truck _TruckExecutor { get; set; }
        protected Driver _DriverExecutor { get; set; }
        protected Route _TaskRoute { get; set; }
        protected Cargo _Cargo { get; set; }

        public Task(string name, Truck truck, Driver driver, Route route, Cargo cargo)
        {
            _Name = name;
            _TruckExecutor = truck;
            _DriverExecutor = driver;
            _TaskRoute = route;
            _Cargo = cargo;
        }

        public override string ToString() => $"{getName} ({getDriverExecutor}; {getTruckExecutor}): {getTaskRoute} | {getCargo}";

        public string getName => $"{_Name}";
        public string getTruckExecutor => $"{_TruckExecutor.getName}";
        public string getDriverExecutor => $"{_DriverExecutor}";
        public string getTaskRoute => $"{_TaskRoute.GetRoute}; {_TaskRoute.GetTime()}";
        public string getCargo => $"{_Cargo.TypeToString}; {_Cargo.WeightToString}; {_Cargo.VolumeToString};";
    }
}   