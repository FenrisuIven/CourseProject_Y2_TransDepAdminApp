using System;
using System.Windows.Media;
using TransDep_AdminApp.Interfaces;

namespace TransDep_AdminApp.Model.Trucks 
{
    public class Tent : Truck
    {
        //TODO: Check if those values are correct
        public static double[] allowedUsefulVolume = { 50, 90 };
        public static double[] allowedCarryingCapacity = { 50, 90 };
        public static double[] allowedCapacity = { 50, 90 };
        //TODO: ---------------------------------
        public Tent(string id, string driverId, string name, int carryingCapacity, int usefulVolume, int capacity, int parkingSpot, Color assignedColor,bool availability = true) 
            : base(id, driverId ,name, carryingCapacity, usefulVolume, capacity, availability, parkingSpot, assignedColor) { }
        
    }
}