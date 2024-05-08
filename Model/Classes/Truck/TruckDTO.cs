namespace TransDep_AdminApp
{
    public class TruckDTO
    {
        public TruckType Type { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public int CarryingCapacity { get; set; }
        public int UsefulVolume { get; set; }
        public int Capacity { get; set; }
        public bool Availability { get; set; }
        
        public TruckDTO () {}
    }
}