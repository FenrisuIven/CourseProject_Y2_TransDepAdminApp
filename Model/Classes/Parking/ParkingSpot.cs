using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using TransDep_AdminApp.View.Screens;

namespace TransDep_AdminApp.Model.Parking
{
    public class ParkingSpot : INotifyPropertyChanged

    {
        public int SpotNum { get; private set; }
        public bool Available { get; private set; }
        public string TruckID { get; private set; }

        public ParkingSpot() { }

        public ParkingSpot(int spotNum, string truckId = null, bool available = true)
        {
            SpotNum = spotNum;
            Available = available;
            TruckID = truckId;
        }

        public void TakeSpot(string truckID)
        {
            Available = false;
            TruckID = truckID;
            OnPropertyChanged();
        }

        public void FreeSpot()
        {
            Available = true;
            TruckID = null;
            OnPropertyChanged();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}