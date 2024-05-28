using System;
using System.ComponentModel;
using System.Data;
using System.Linq;
using TransDep_AdminApp.Enums;
using System.Text.RegularExpressions;
using TransDep_AdminApp.Interfaces;
using TransDep_AdminApp.Model;

namespace TransDep_AdminApp.ViewModel.Validation
{
    public class CargoValidation : IDataErrorInfo, IValidationValid
    {
        public string Weight { get; set; }
        public string Volume { get; set; }
        public string Amount { get; set; }
        private CargoType? _type;
        
        public LoadValidationForChosenTruck TargetLoadValidationForChosenTruck { get; set; }
        public void OnLoadValidationForChosenTruckChanged(object sender, PropertyChangedEventArgs e)
        {
            TargetLoadValidationForChosenTruck = sender as LoadValidationForChosenTruck;
        }
        
        public string Type
        {
            get
            {
                if (_type == null) return default;
                return CargoTypeConverter.dictionary[_type.Value];
            }
            set
            {
                _type = CargoTypeConverter.dictionary.FirstOrDefault(elem => elem.Value == value).Key;
            }
        }

        public bool IsValid() => 
            GetType().GetProperties()
                .Select(elem => elem.Name)
                .All(property => string.IsNullOrEmpty(this[property]));
        
        public string this[string name]
        {
            get
            {
                switch (name)
                {
                    case"Weight":
                        if (string.IsNullOrEmpty(Weight)) { return "Вага вантажу обов'язкова"; }
                        if (new Regex("[^0-9.-]+").IsMatch(Weight)) { return "Вага вантажу повинна містити лише цифри"; }
                        
                        TargetLoadValidationForChosenTruck.CarryCap = int.Parse(Weight);
                        if (ValidateLoad(name) != null) return ValidateLoad(name); 
                        break;
                    case "Volume":
                        if (string.IsNullOrEmpty(Volume)) { return "Об'єм вантажу обов'язковий"; }
                        if (new Regex("[^0-9.-]+").IsMatch(Volume)) { return "Об'єм вантажу повинен містити лише цифри"; }
                        
                        TargetLoadValidationForChosenTruck.UseVolume = int.Parse(Volume);
                        if (ValidateLoad(name) != null) return ValidateLoad(name); 
                        break;
                    case "Amount":
                        if (string.IsNullOrEmpty(Amount)) return "Кількість вантажу обов'язкова";
                        if (new Regex("[^0-9.-]+").IsMatch(Amount)) return "Кількість вантажу повинна містити лише цифри";
                        
                        TargetLoadValidationForChosenTruck.Capacity = int.Parse(Amount);
                        if (ValidateLoad(name) != null) return ValidateLoad(name); 
                        break;
                    case "Type":
                        if (Type is null) return "Тип вантажу обов'язковий";
                        if (!CargoTypeConverter.dictionary.ContainsValue(Type)) return "Обраний тип не підтримується";
                        break;
                }
                return null;
            }
        }

        private string ValidateLoad(string name)
        {
            if (!string.IsNullOrEmpty(TargetLoadValidationForChosenTruck[name])) return TargetLoadValidationForChosenTruck[name];
            return default;
        }
        
        public string Error => null;
    }
}