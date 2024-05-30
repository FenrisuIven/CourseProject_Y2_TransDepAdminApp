using System;
using System.Windows.Media;
using TransDep_AdminApp.Interfaces;

namespace TransDep_AdminApp.Model.Trucks 
{
    public class Tent : Truck
    {
        public static double[] allowedUsefulVolume = { 20, 25 };
        public static double[] allowedCarryingCapacity = { 60, 95 };
        public static double[] allowedCapacity = { 20, 30 };
        public Tent(string id, string driverId, string name, int carryingCapacity, int usefulVolume, int capacity, int parkingSpot, Color assignedColor,bool availability = true) 
            : base(id, driverId ,name, carryingCapacity, usefulVolume, capacity, availability, parkingSpot, assignedColor) { }
        
    }
}