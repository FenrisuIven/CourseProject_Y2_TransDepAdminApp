using System;
using System.Windows.Media;

namespace TransDep_AdminApp.Model.Trucks
{
    public class Container : Truck
    {
        public static int[] allowedUsefulVolume = { 25, 30 };       
        public static int[] allowedCarryingCapacity = { 60, 70 };
        public static int[] allowedCapacity = { 20, 30 };
        public Container(string _id, string _driverId, string _name, int _carryingCapacity, int _usefulVolume, int _capacity, int _parkingSpot, Color _assignedColor, bool _availability = true)
            : base(_id, _driverId, _name, _carryingCapacity, _usefulVolume, _capacity, _availability, _parkingSpot, _assignedColor)
        {
        }
    }
}