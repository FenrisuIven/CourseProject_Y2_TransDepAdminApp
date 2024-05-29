using System;
using System.Windows.Media;
using TransDep_AdminApp.Interfaces;

namespace TransDep_AdminApp.Model.Trucks
{
    public class Refrigerated : Truck
    {
        public static int[] allowedUsefulVolume = { 10, 20 };
        public static int[] allowedCarryingCapacity = { 60, 90 };
        public static int[] allowedCapacity = { 25, 30 };
        public Refrigerated(string _id, string _driverId, string _name, int _carryingCapacity, int _usefulVolume, int _capacity, int _parkingSpot, Color _assignedColor,bool _availability = true ) 
            : base(_id, _driverId, _name, _carryingCapacity, _usefulVolume, _capacity, _availability, _parkingSpot, _assignedColor) { }
    }
}