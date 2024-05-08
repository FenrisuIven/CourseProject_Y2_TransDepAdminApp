namespace TransDep_AdminApp.Trucks
{
    public class Tent : Truck
    {
        public Tent(string _name, 
            int carryingCapacity, 
            int usefulVolume, 
            int capacity, 
            bool _availability = true)
        {
            Name = _name;
            CarryingCapacity = carryingCapacity;
            UsefulVolume = usefulVolume;
            Capacity = capacity;
            Availability = _availability;
        }
    }
}