using System;
using System.Windows;
using System.Windows.Data;
using System.Globalization;
using System.Windows.Controls;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Collections.ObjectModel;
using System.Linq;


namespace TransDep_AdminApp.Parking
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

        private static List<(int place, bool taken)> _takenPlaces;
        
        public static void Initialize()
        {
            _parkedtrucks = new ObservableCollection<ParkedTruck> {
                new (0, 0, MainController.Instance.truckList[0].Id),
                new (0, 1, MainController.Instance.truckList[1].Id),
                new (0, 4, MainController.Instance.truckList[2].Id),
                new (0, 7, MainController.Instance.truckList[3].Id),
                new (0, 8, MainController.Instance.truckList[4].Id),
                new (1, 0, MainController.Instance.truckList[5].Id)
            };
            if (_takenPlaces != null) return;
            
            _takenPlaces = new();
            int count = 1;
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    var truck = _parkedtrucks.ToList().Find(elem => elem.Row == i && elem.Col == j);
                    _takenPlaces.Add((count, truck != null && truck.Availability));
                    count++;
                }
            }

            var k = 0;
        }

        public static void AddParkedTruck(Truck target)
        {
            var row = (target.ParkingSpot - 1) / 9;
            var col = (target.ParkingSpot - 1) % 9;
            _parkedtrucks.Add(new ParkedTruck(row, col, target.Id));
        }
        
        public static int GetFreeSpotNum() => _takenPlaces.Find(elem => !elem.taken).place;
        public static void TakePlace(int place)
        {
            var targetPlace = _takenPlaces.Find(elem => elem.place == place);
            if (targetPlace.taken) throw new ArgumentException("Targeted place is already taken");
            _takenPlaces = _takenPlaces.ToImmutableList().Replace(targetPlace, (targetPlace.place, true)).ToList();
        }
        
        public static ObservableCollection<ParkedTruck> GetTrucksOnLot 
        {
            get
            {
                var availableTrucks = new ObservableCollection<ParkedTruck>(ParkedTrucks.Where(elem => elem.Availability).Select(elem => elem).ToList());
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

