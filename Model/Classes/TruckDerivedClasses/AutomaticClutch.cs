using System;

namespace TransDep_AdminApp.Model.Trucks
{
    public class AutomaticClutch : Truck
    {
        //TODO: Check if those values are correct
        public static double[] allowedUsefulVolume = { 50, 90 };
        public static double[] allowedCarryingCapacity = { 50, 90 };
        public static double[] allowedCapacity = { 50, 90 };
        //TODO: ---------------------------------
        
        public AutomaticClutch(string _id, string _driverId, string _name, int _carryingCapacity, int _usefulVolume, int _capacity, int _parkingSpot,
            bool _availability = true) 
            : base(_id, _driverId,_name, _carryingCapacity, _usefulVolume, _capacity, _availability, _parkingSpot)
        {
        }
    }
}