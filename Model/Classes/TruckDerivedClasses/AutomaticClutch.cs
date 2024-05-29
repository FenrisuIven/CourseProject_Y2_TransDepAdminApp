using System;
using System.Windows.Media;

namespace TransDep_AdminApp.Model.Trucks
{
    public class AutomaticClutch : Truck
    {
        public static double[] allowedCarryingCapacity = { 50, 90 }; //Вантажопідйомність
        public static double[] allowedUsefulVolume = { 50, 90 };     //Корисний обсяг
        public static double[] allowedCapacity = { 50, 90 };         //Місткість
        
        public AutomaticClutch(
            string _id, string _driverId, string _name, 
            int _carryingCapacity, int _usefulVolume, int _capacity, 
            int _parkingSpot, Color _assignedColor, bool _availability = true) 
            : base(_id, _driverId, _name, 
                _carryingCapacity, _usefulVolume, 
                _capacity, _availability, _parkingSpot, _assignedColor) { }
    }
}