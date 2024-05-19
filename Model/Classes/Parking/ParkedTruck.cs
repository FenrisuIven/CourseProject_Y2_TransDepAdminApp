using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;

namespace TransDep_AdminApp.Parking
{
    public class ParkedTruck : INotifyPropertyChanged
    {
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
            var truckDto = MainController.Instance.truckList.Find(elem => elem.Id == truckId);
            var driverDto = MainController.Instance.driverList.Find(elem => elem.AssignedTruckID == truckId);
            var driver = ObjectMapper.Map<Driver>(driverDto);

            Row = row;
            Col = col;
            TruckId = truckId;
            _name = truckDto.Name;
            Availability = truckDto.Availability;
            DriverName = driver.LastName + " " + driver.FirstName.ToCharArray()[0] + "." + driver.MiddleName.ToCharArray()[0] + ".";
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
