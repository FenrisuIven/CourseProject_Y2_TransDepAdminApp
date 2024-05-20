namespace TransDep_AdminApp.Interfaces
{
    public interface ITruck
    {
        void SetParkingSpot(int value);
        void SetDriverID(string value);
        void SetAvailability(bool value);
    }
}