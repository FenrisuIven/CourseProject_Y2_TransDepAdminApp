namespace TransDep_AdminApp
{
    public class TaskDTO
    {
        public string Name { get; set; }
        public TruckDTO TruckExecutor { get; set; }
        public DriverDTO DriverExecutor { get; set; }
        public RouteDTO Route { get; set; }
        public CargoDTO Cargo { get; set; }
        
        public TaskDTO() {}
    }
}