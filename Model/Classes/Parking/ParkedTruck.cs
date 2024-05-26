using System.Linq;
using System.ComponentModel;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

using TransDep_AdminApp.ViewModel;

namespace TransDep_AdminApp.Model.Parking
{
    public class ParkedTruck : INotifyPropertyChanged
    {
        public ParkingSpot Spot { get; private set; }
        public int Row { get; private set; }
        public int Col { get; private set; }
        public string TruckId { get; private set; }
        public string DriverName { get; private set; }
        
        private bool _availability;
        public bool Availability
        {
            get => _availability; 
            private set => SetField(ref _availability, value);
        }
        
        private string _name;
        public string Name
        {
            get => ShortenName();
        }

        
        private int _maxLength = 10;
        public ParkedTruck() {}
        public ParkedTruck(int row, int col, string truckId)
        {
            var truckDto = MainController.Instance.truckList.ToList().Find(elem => elem.Id == truckId);
            var driverDto = MainController.Instance.driverList.ToList().Find(elem => elem.AssignedTruckId == truckId);
            var driver = ObjectMapper.AutoMapper.Map<Driver>(driverDto);

            Row = row;
            Col = col;
            TruckId = truckId;
            _name = truckDto.Name;
            Availability = truckDto.Availability;
            DriverName = driver.LastName + " " + driver.FirstName.ToCharArray()[0] + "." + driver.MiddleName.ToCharArray()[0] + ".";
        }

        public ParkedTruck(ParkingSpot spot, string truckId)
        {
            var truckDto = MainController.Instance.truckList.ToList().Find(elem => elem.Id == truckId);

            Spot = spot;
            Row = spot.Row;
            Col = spot.Col;
            TruckId = truckId;
            _name = truckDto.Name;
            Availability = truckDto.Availability;
            
            var driverDto = MainController.Instance.driverList.ToList().Find(elem => elem.AssignedTruckId == truckId);
            if (driverDto != null)
            {
                var driver = ObjectMapper.AutoMapper.Map<Driver>(driverDto);
                DriverName = driver.LastName + " " + 
                             driver.FirstName.ToCharArray()[0] + "." +
                             driver.MiddleName.ToCharArray()[0] + ".";
            }
            else DriverName = "Unassigned";
        }
        
        private string ShortenName()
        {
            var firstPart = _name.Split(' ')[0];
            if (firstPart.Length <= _maxLength) return firstPart;
            var charArr = firstPart.ToCharArray().ToList();
            return string.Join("", charArr.Take(_maxLength - 3)) + "...";
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        protected bool SetField<T>(ref T field, T value, [CallerMemberName] string propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(field, value)) return false;
            field = value;
            OnPropertyChanged(propertyName);
            return true;
        }
    }
}
