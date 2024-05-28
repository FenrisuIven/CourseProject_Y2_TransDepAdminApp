using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using TransDep_AdminApp.Model;
using TransDep_AdminApp.Model.Parking;

namespace TransDep_AdminApp.ViewModel
{
    public class ParkingLotVM
    {
        public ObservableCollection<ParkedTruck> ParkedTrucks;

        public ParkingLotVM()
        {
            Initialize();
            ParkingLotM.Instance.SpotAvailabilityChanged += Initialize;
        }

        public void Initialize()
        {
            ParkedTrucks = new();
            foreach (var spot in ParkingLotM.Instance.ParkingSpots)
            {
                if (spot.Available) continue;
                ParkedTrucks.Add(new ParkedTruck(spot.SpotNum, spot.TruckID));
                ParkedTrucks.Last().SetRowColIdx(18);
            }
            OnLotChanged();
        }

        public delegate void OnLotSpotsChanged();
        public event OnLotSpotsChanged LotChanged;
        public void OnLotChanged() => LotChanged?.Invoke();
    }
}

