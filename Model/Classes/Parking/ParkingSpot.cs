namespace TransDep_AdminApp.Model
{
    public class ParkingSpot
    {
        public int SpotNum { get; set; }
        public ParkingSpot() {}

        public ParkingSpot(int spotNum)
        {
            SpotNum = spotNum;
        }
    }
}