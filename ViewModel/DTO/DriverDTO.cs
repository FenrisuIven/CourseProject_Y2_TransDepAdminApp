namespace TransDep_AdminApp.ViewModel.DTO
{
    public class DriverDTO
    {
        public string Id { get; set; }
        public string FullName { get; set; }
        public string AssignedTruckID { get; set; }
        public int Rating { get; set; }
        public string Category { get; set; }
        
        public DriverDTO(){}
    }
}