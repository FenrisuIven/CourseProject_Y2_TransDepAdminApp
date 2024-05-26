namespace TransDep_AdminApp.ViewModel.DTO
{
    public class TaskDTO
    {
        public string Name { get; set; }
        public string TruckExecutorID { get; set; }
        public string DriverExecutorID { get; set; }
        public RouteDTO Route { get; set; }
        public CargoDTO Cargo { get; set; }
        
        public TaskDTO() {}
    }
}