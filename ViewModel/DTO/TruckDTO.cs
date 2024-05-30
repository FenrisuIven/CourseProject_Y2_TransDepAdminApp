using System.Windows.Media;
using TransDep_AdminApp.Enums;

namespace TransDep_AdminApp.ViewModel.DTO
{
    public class TruckDTO
    {
        public TruckType Type { get; set; }
        public string Id { get; set; }
        public string DriverID { get; set; }
        public Color AssignedColor { get; set; }
        
        public string Name { get; set; }
        public int CarryingCapacity { get; set; }
        public int UsefulVolume { get; set; }
        public int Capacity { get; set; }
        public bool Availability { get; set; }
        public int ParkingSpot { get; set; }

        public TruckDTO () {}
    }
}