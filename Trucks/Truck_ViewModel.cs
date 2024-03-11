using System;
using System.ComponentModel;
using System.Collections.ObjectModel;

namespace TransDep_AdminApp.Trucks
{
    public class Truck_ViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<Truck> _trucks;

        public Truck_ViewModel()
        {
            Trucks = new ObservableCollection<Truck>();
        }

        public ObservableCollection<Truck> Trucks
        {
            get { return _trucks; }
            set
            {
                _trucks = value;
                OnPropertyChanged(nameof(Trucks));
            }
        }

        // Implement INotifyPropertyChanged interface here
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}