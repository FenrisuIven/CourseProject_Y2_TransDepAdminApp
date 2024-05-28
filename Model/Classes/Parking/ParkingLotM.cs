using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace TransDep_AdminApp.Model.Parking
{
    public class ParkingLot
    {
        private static ParkingLot _instance;
        public static ParkingLot Instance
        {
            get
            {
                if (_instance == null) _instance = new();
                return _instance;
            }
        }

        public ObservableCollection<ParkingSpot> ParkingSpots;
        
        public ParkingLot()
        {
            Initialize();
            RefreshAvailability();
        }

        public void TakeSpot(int spotNum, string truckID) => ParkingSpots[spotNum - 1].TakeSpot(truckID);
        public void FreeSpot(int spotNum) => ParkingSpots[spotNum - 1].FreeSpot();

        public int GetFirstFree() => ParkingSpots.ToList().Find(elem => elem.Available == false).SpotNum;

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
    }
}