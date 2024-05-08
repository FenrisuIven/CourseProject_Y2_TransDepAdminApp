namespace TransDep_AdminApp.Trucks
{
    public class Container : Truck
    {
        public Container(string _name, 
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