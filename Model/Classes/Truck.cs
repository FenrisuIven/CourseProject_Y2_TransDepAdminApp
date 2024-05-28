#nullable enable
using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

using TransDep_AdminApp.Interfaces;

namespace TransDep_AdminApp.Model
{
    public abstract class Truck
    {
        #region Fields
        public string Id { get; protected set; }
        public string? DriverID { get; protected set; }
        public string Name { get; protected set; }
        public int CarryingCapacity { get; protected set; }
        public int UsefulVolume { get; protected set; }
        public int Capacity { get; protected set; }
        public bool Availability { get; protected set; }
        public int? ParkingSpot { get; protected set; }
        #endregion
        public Truck() {}
        
        public Truck(
            string id, string? driverId, string name, 
            int carryingCapacity, int usefulVolume, int capacity, 
            bool availability, int parkingSpot)
        {
            Id = id;
            DriverID = driverId;
            Name = name;
            CarryingCapacity = carryingCapacity;
            UsefulVolume = usefulVolume;
            Capacity = capacity;
            Availability = availability;
            ParkingSpot = parkingSpot;
        }

        public void SetAvailability(bool val) =>  Availability = val;
        public void SetParkingSpot(int? value) => ParkingSpot = value;
        public void SetDriverID(string value) => DriverID = value;
        
    }
}
