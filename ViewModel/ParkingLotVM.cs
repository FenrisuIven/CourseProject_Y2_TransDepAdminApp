using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Windows.Media.Animation;
using TransDep_AdminApp.Model;
using TransDep_AdminApp.Model.Parking;
using TransDep_AdminApp.View;

namespace TransDep_AdminApp.ViewModel
{
    public class ParkingLotVM
    {
        public ObservableCollection<ParkedTruck> ParkedTrucks { get; set; }
        
        private static ParkingLotVM _instance;
        public static ParkingLotVM Instance
        {
            get
            {
                if (_instance == null) _instance = new ParkingLotVM();
                return _instance;
            }
        }
        
        private ParkingLotVM()
        {
            Initialize();
            ParkingLotM.Instance.SpotAvailabilityChanged += Initialize;
        }

        public void Initialize()
        {
            if (ParkedTrucks != null) return;
            ParkedTrucks = new();
            foreach (var spot in ParkingLotM.Instance.ParkingSpots)
            {
                if (spot.Available) continue;
                ParkedTrucks.Add(new ParkedTruck(spot.SpotNum, spot.TruckID));
                ParkedTrucks.Last().SetRowColIdx(18);
            }
            OnLotChanged();
        }

        public delegate void AnimateTruck(string id, string type);
        public event AnimateTruck OnAnimateTruck;
        public void RequestTruckAnimation(string id, string type) => OnAnimateTruck?.Invoke(id, type);
        
        public delegate void OnLotSpotsChanged();
        public event OnLotSpotsChanged LotChanged;
        public void OnLotChanged() => LotChanged?.Invoke();
    }
}

