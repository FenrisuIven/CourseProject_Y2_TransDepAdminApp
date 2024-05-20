using TransDep_AdminApp.Enums;

namespace TransDep_AdminApp.ViewModel.DTO
{
    public class CargoDTO
    {
        public double Weight { get; set; }
        public double Volume { get; set; }
        public double Amount { get; set; }
        public CargoType Type { get; set; }
        
        public CargoDTO () {}
    }
}