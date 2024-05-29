using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.IO.Ports;
using System.Linq;

namespace TransDep_AdminApp.Model.Parking
{
    public class ParkingLotM
    {
        private static ParkingLotM _instance;
        public static ParkingLotM Instance
        {
            get
            {
                if (_instance == null) _instance = new();
                return _instance;
            }
        }

        public ObservableCollection<ParkingSpot> ParkingSpots { get; set; }
        
        public ParkingLotM()
        {
            Initialize();
            RefreshAvailability();
            MainController.Instance.FinishedChanges += OnSpotAvailChanged;
        }

        public void TakeSpot(int spotNum, string truckID) => ParkingSpots[spotNum - 1].TakeSpot(truckID);
        public void FreeSpot(int spotNum) => ParkingSpots[spotNum - 1].FreeSpot();

        public int GetFirstFree() => ParkingSpots.ToList().Find(elem => elem.Available == true).SpotNum;

        public int TakeFirstFreeSpot(string truckId)
        {
            var num = GetFirstFree();
            TakeSpot(num, truckId);
            return num;
        }
        
        public void Initialize()
        {
            ParkingSpots = new();
            for (int i = 1; i <= 18; i++)
            {
                ParkingSpots.Add(new ParkingSpot(i));
            }
        }

        public void RefreshAvailability()
        {
            foreach (var truck in MainController.Instance.truckList)
            {
                if (truck.ParkingSpot == null || truck.Availability == false) continue;
                ParkingSpots[truck.ParkingSpot!.Value - 1].TakeSpot(truck.Id);
            }
        }

        public delegate void SpotAvailChanged();
        public event SpotAvailChanged SpotAvailabilityChanged;
        public void OnSpotAvailChanged()
        {
            SpotAvailabilityChanged?.Invoke();
        }
    }
}