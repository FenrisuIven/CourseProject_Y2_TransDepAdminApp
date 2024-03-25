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
        
        public static List<Truck> GetTruckList => trucks;
        public static void SetTruckList(List<Truck> list)
        {
            trucks = new List<Truck>();
            foreach (var truck in list) trucks.Add(truck);
        }

        public static Truck GetTruckFromList(int idx) => trucks.ElementAt(idx);
        public static void AddNewTruck(Truck truck) => trucks.Add(truck);
        
        public static void RemoveTruck(Truck truck) => trucks.Remove(truck);
        public static void RemoveTruck(int idx) => trucks.Remove(trucks.ElementAt(idx));
    }
}