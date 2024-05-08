namespace TransDep_AdminApp
{
    public class CargoDTO
    {
        public double Weight { get; set; }
        public double Volume { get; set; }
        public CargoType Type { get; set; }
        
        public CargoDTO () {}
    }
}