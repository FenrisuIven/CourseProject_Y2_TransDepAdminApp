namespace TransDep_AdminApp
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