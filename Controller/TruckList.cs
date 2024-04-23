using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using TransDep_AdminApp;
using TransDep_AdminApp.Trucks;

namespace TransDep_AdminApp
{
    public class TruckList
    {
        private static List<Truck> trucks;

        public TruckList() {}
        
        public List<Truck> GetTruckList => trucks;
        public void SetTruckList(List<Truck> list)
        {
            trucks = new List<Truck>();
            foreach (var truck in list) trucks.Add(truck);
        }

        public Truck GetTruckFromList(int idx) => trucks.ElementAt(idx);
        public void AddNewTruck(Truck truck) => trucks.Add(truck);
        
        public void RemoveTruck(Truck truck) => trucks.Remove(truck);
        public void RemoveTruck(object truck) => trucks.Remove((Truck)truck);
        public void RemoveTruck(int idx) => trucks.Remove(trucks.ElementAt(idx));
    }
}