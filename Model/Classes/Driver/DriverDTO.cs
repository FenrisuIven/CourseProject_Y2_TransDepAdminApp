namespace TransDep_AdminApp
{
    public class DriverDTO
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Rating { get; set; }
        public int AssignedTruckID { get; set; }
        
        public DriverDTO(){}
    }
}