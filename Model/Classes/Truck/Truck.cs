using System;

namespace TransDep_AdminApp
{
    public abstract class Truck
    {
        public int Id { get; protected set; }
        public string Name { get; protected set; }
        public int CarryingCapacity { get; protected set; }
        public int UsefulVolume { get; protected set; }
        public int Capacity { get; protected set; }
        public bool Availability { get; protected set; }

        protected Truck(int _id, string _name, int _carryingCapacity, int _usefulVolume, int _capacity, bool _availability)
        {
            Id = _id;
            Name = _name;
            CarryingCapacity = _carryingCapacity;
            UsefulVolume = _usefulVolume;
            Capacity = _capacity;
            Availability = _availability;
        }
    }
}