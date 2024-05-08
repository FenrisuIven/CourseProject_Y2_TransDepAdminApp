using System;
using System.Runtime.InteropServices;
using System.Windows;
using System.Xml.Schema;

namespace TransDep_AdminApp.Trucks
{
    public class Refrigerated : Truck
    {
        private new int[] allowedUsefulVolume = { 50, 90 };
        private new int[] allowedCarryingCapacity = { 20, 25 };
        private new int[] allowedCapacity = { 20, 25 };
        public Refrigerated(string _name, 
            int carryingCapacity, 
            int usefulVolume, 
            int capacity, 
            bool _availability = true)
        {
            //Check(carryingCapacity, usefulVolume, capacity);
            
            Name = _name;
            CarryingCapacity = carryingCapacity;
            UsefulVolume = usefulVolume;
            Capacity = capacity;
            Availability = _availability;
        }

        

    }
}