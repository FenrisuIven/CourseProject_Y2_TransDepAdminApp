using System;
using TransDep_AdminApp.Interfaces;

namespace TransDep_AdminApp.Model.Trucks
{
    public class Refrigerated : Truck, ITruck
    {
        //TODO: Check if those values are correct
        public static int[] allowedUsefulVolume = { 50, 90 };
        public static int[] allowedCarryingCapacity = { 50, 90 };
        public static int[] allowedCapacity = { 50, 90 };
        //TODO: ---------------------------------
        public Refrigerated(string _id, string _driverId, string _name, int _carryingCapacity, int _usefulVolume, int _capacity, int _parkingSpot, bool _availability = true ) 
            : base(_id, _driverId, _name, _carryingCapacity, _usefulVolume, _capacity, _availability, _parkingSpot) { }

        public void SetParkingSpot(int value)
        {
            ParkingSpot = value;
        }

        public void SetDriverID(string value)
        {
            DriverID = value;
        }
    }
}