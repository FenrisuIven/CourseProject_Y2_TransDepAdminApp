namespace TransDep_AdminApp.Trucks
{
    public class Container : Truck
    {
        public Container(string _name, 
            int[] _carryingCapacity, 
            int[] _usefulVolume, 
            int[] _capacity, 
            bool _availability)
        {
            Name = _name;
            CarryingCapacity = _carryingCapacity;
            UsefulVolume = _usefulVolume;
            Capacity = _capacity;
            Availability = _availability;
        }
    }
}