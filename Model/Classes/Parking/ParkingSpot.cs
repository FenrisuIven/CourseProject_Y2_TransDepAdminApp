namespace TransDep_AdminApp.Model.Parking
{
    public struct ParkingSpot
    {
        public int SpotNum { get; private set; }
        public int Row { get; private set; }
        public int Col { get; private set; }
        public bool Taken { get; set; }

        public ParkingSpot(int spotNum, int amountOfSpots)
        {
            SpotNum = spotNum;
            Row = (spotNum - 1) / (amountOfSpots / 2);
            Col = (spotNum - 1) % (amountOfSpots / 2);
            Taken = false;
        }
    }
}