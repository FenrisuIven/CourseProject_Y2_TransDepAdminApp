#nullable enable
using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Windows.Media;
using TransDep_AdminApp.Interfaces;

namespace TransDep_AdminApp.Model
{
    public abstract class Truck
    {
        #region Fields
        public string Id { get; protected set; }
        public string? DriverID { get; protected set; }
        public Color AssignedColor { get; protected set; }
        public string Name { get; protected set; }
        public int CarryingCapacity { get; protected set; }
        public int UsefulVolume { get; protected set; }
        public int Capacity { get; protected set; }
        public int? ParkingSpot { get; protected set; }
        public bool Availability { get; protected set; }
        #endregion
        public Truck() {}
        
        public Truck(
            string id, string? driverId, string name, 
            int carryingCapacity, int usefulVolume, int capacity, 
            bool availability, int parkingSpot, Color assignedColor)
        {
            Id = id;
            DriverID = driverId;
            AssignedColor = assignedColor;
            Name = name;
            CarryingCapacity = carryingCapacity;
            UsefulVolume = usefulVolume;
            Capacity = capacity;
            Availability = availability;
            ParkingSpot = parkingSpot;
        }

        public void SetAvailability(bool val)
        {
            Availability = val;
            OnAvailChanged();
        }

        public void SetParkingSpot(int? value) => ParkingSpot = value;
        public void SetDriverID(string value) => DriverID = value;

        
        public delegate void OnPropChanged(string id, bool newAvail);
        public event OnPropChanged AvailabilityChanged;
        protected void OnAvailChanged()
        {
            AvailabilityChanged?.Invoke(Id, Availability);
        }
    }
}
