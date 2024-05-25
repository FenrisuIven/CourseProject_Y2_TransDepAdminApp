using System;
using System.Windows;
using System.Windows.Data;
using System.Globalization;
using System.Windows.Controls;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Collections.ObjectModel;
using System.Linq;
using TransDep_AdminApp.ViewModel;
using TransDep_AdminApp.ViewModel.DTO;


namespace TransDep_AdminApp.Model.Parking
{
    public class ParkingLot
    {

        private static ObservableCollection<ParkedTruck> _parkedtrucks;
        public static ObservableCollection<ParkedTruck> ParkedTrucks
        {
            get
            {
                if (_parkedtrucks == null) Initialize();
                return _parkedtrucks;
            }
        }

        private static ParkingSpot[] _takenPlaces;
        private static int amountOfSpots = 18;
        
        public static void Initialize()
        {
            _parkedtrucks = new ObservableCollection<ParkedTruck>(
                MainController.Instance.truckList.ToList()
                    .Where(elem => elem.ParkingSpot != null)
                    .Select(elem => new ParkedTruck(new ParkingSpot(elem.ParkingSpot.Value, amountOfSpots), elem.Id)));
            
            if (_takenPlaces != null) return;
            
            _takenPlaces = new ParkingSpot[amountOfSpots];
            for (int i = 0; i < amountOfSpots; i++)
            {
                _takenPlaces[i] = new ParkingSpot(i + 1, amountOfSpots);
                if (_parkedtrucks.ToList().Find(elem => elem.Spot.SpotNum == _takenPlaces[i].SpotNum) != null)
                {
                    _takenPlaces[i].Taken = true;
                }
            }
        }

        public static void AddParkedTruck(TruckDTO target)
        {
            _parkedtrucks.Add(new ParkedTruck(new ParkingSpot(target.ParkingSpot, amountOfSpots), target.Id));
        }
        public static void AddParkedTruck(string truckId)
        {
            var target = MainController.Instance.truckList.ToList().Find(elem => elem.Id == truckId);
            _parkedtrucks.Add(new ParkedTruck(new ParkingSpot((int)target.ParkingSpot!, amountOfSpots), target.Id));
        }
        
        public static int GetFreeSpotNum() => _takenPlaces.ToList().Find(elem => !elem.Taken).SpotNum;
        public static void TakePlace(int place)
        {
            var idx = _takenPlaces.ToList().FindIndex(elem => elem.SpotNum == place);
            if (_takenPlaces[idx].Taken) throw new ArgumentException("Targeted place is already taken");
            _takenPlaces[idx].Taken = true;
        }
        
        public static ObservableCollection<ParkedTruck> GetTrucksOnLot 
        {
            get
            {
                var availableTrucks = new ObservableCollection<ParkedTruck>(ParkedTrucks.Select(elem => elem).ToList());
                return availableTrucks;
            }
        }
    }
    
    public class ColumnToCanvasLeftConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int column = (int)value;
            
            return column * (700 / 9) + 7;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
    public class RowToCanvasTopConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int row = (int)value;
            return row * 480 + 15;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

