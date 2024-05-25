using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using TransDep_AdminApp.Model;
using TransDep_AdminApp.Model.Trucks;
using Container = System.ComponentModel.Container;

namespace TransDep_AdminApp.ViewModel.Validation
{
    public class LoadValidationForChosenTruck : IDataErrorInfo, INotifyPropertyChanged
    {
        private double? carryingCapacity;
        private double? capacity;
        private double? usefulVolume;
        public int? CarryCap { get; set; }
        public int? UseVolume { get; set; }
        public int? Capacity { get; set; }

        private static Truck _targetTruck;
        public Truck TargetTruck
        {
            set
            {
                _targetTruck = value;
                UpdateFields();
                OnPropertyChanged();
            }
        }

        public LoadValidationForChosenTruck() {}
        public LoadValidationForChosenTruck(Truck targetTruck)
        {
            carryingCapacity = targetTruck.CarryingCapacity;
            capacity = targetTruck.Capacity;
            usefulVolume = targetTruck.UsefulVolume;
        }

        private void UpdateFields()
        {
            carryingCapacity = _targetTruck?.CarryingCapacity;
            capacity = _targetTruck?.Capacity;
            usefulVolume = _targetTruck?.UsefulVolume;
        }
        public string this[string name]
        {
            get
            {
                switch (name)
                {
                    case "Weight":
                        if (CarryCap > carryingCapacity) 
                            return $"Вага перевищує максимальну для обраної вантажівки: {carryingCapacity} тонн";
                        break;
                    
                    case "Volume":
                        if (UseVolume > usefulVolume) 
                            return $"Об'єм перевищує максимальний для обраної вантажівки: {usefulVolume} м. куб";
                        break;
                    
                    case "Amount":
                        if (Capacity > capacity) 
                            return $"Кількість перевищує максимальну для обраної вантажівки: {capacity} європалетів";
                        break;
                }

                return default;
            }
        }

        public string Error => null;
        
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