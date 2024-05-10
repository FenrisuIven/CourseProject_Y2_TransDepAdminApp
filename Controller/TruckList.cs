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
        private static List<TruckDTO> trucks;

        public TruckList() {}
        
        public List<TruckDTO> GetTruckList => trucks;
        public void SetTruckList(List<Truck> list)
        {
            trucks = new List<TruckDTO>();
            list.ForEach(elem => trucks.Add(ObjectMapper.Map<TruckDTO>(elem)));
        }

        public TruckDTO GetTruckFromList(int idx) => trucks.ElementAt(idx);
        public void AddNewTruck(TruckDTO truck) => trucks.Add(truck);
        public void RemoveTruck(TruckDTO truck) => trucks.Remove(truck);
    }
}