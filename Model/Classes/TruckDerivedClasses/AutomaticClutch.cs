namespace TransDep_AdminApp.Trucks
{
    public class AutomaticClutch : Truck
    {
        public AutomaticClutch(string _name, 
            int carryingCapacity, 
            int usefulVolume, 
            int capacity, 
            bool _availability)
        {
            Name = _name;
            CarryingCapacity = carryingCapacity;
            UsefulVolume = usefulVolume;
            Capacity = capacity;
            Availability = _availability;
        }
    }
}