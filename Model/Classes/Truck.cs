using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

using TransDep_AdminApp.Interfaces;

namespace TransDep_AdminApp.Model
{
    public class Truck : INotifyPropertyChanged
    {
        public string Id { get; protected set; }
        public string? DriverID { get; protected set; }
        public string Name { get; protected set; }
        public int CarryingCapacity { get; protected set; }
        public int UsefulVolume { get; protected set; }
        public int Capacity { get; protected set; }

        private bool _availability;
        public bool Availability
        {
            get => _availability;
            protected set => SetField(ref _availability, value);
        }

        private int? _parkingSpot;
        public int? ParkingSpot
        {
            get => _parkingSpot; 
            protected set => SetField(ref _parkingSpot, value);
        }

        public Truck() {}
        
        public Truck(string id, string? driverId, string name, int carryingCapacity, int usefulVolume, int capacity, bool availability, int parkingSpot)
        {
            Id = id;
            DriverID = driverId;
            Name = name;
            CarryingCapacity = carryingCapacity;
            UsefulVolume = usefulVolume;
            Capacity = capacity;
            _availability = availability;
            _parkingSpot = parkingSpot;
        }

        public void SetAvailability(bool val) =>  Availability = val;
        public void SetParkingSpot(int? value) => ParkingSpot = value;
        public void SetDriverID(string value) => DriverID = value;
        
        
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        protected bool SetField<T>(ref T field, T value, [CallerMemberName] string propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(field, value)) return false;
            field = value;
            OnPropertyChanged(propertyName);
            return true;
        }
    }
}