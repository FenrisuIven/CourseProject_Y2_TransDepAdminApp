using System;
using System.ComponentModel;
using System.Data;
using TransDep_AdminApp.Enums;
using System.Text.RegularExpressions;

namespace TransDep_AdminApp.ViewModel.Validation
{
    public class CargoValidation : IDataErrorInfo
    {
    
        public string Weight { get; set; }
        public string Volume { get; set; }
        public string Amount { get; set; }

        private CargoType _type;
        public string Type
        {
            get => CargoTypeConverter.dictionary[_type];
            set
            {
                
            }
        }

        public string this[string name]
        {
            get
            {
                switch (name)
                {
                    case "Weight":
                        if (string.IsNullOrEmpty(Weight)) return "Вага вантажу обов'язкова";
                        if (new Regex("[^0-9.-]+").IsMatch(Weight)) return "Вага вантажу повинна містити лише цифри";
                        break;
                    case "Volume":
                        if (string.IsNullOrEmpty(Volume)) return "Об'єм вантажу обов'язковий";
                        if (new Regex("[^0-9.-]+").IsMatch(Volume)) return "Об'єм вантажу повинен містити лише цифри";
                        break;
                    case "Amount":
                        if (string.IsNullOrEmpty(Amount)) return "Кількість вантажу обов'язкова";
                        if (new Regex("[^0-9.-]+").IsMatch(Amount)) return "Кількість вантажу повинна містити лише цифри";
                        break;
                    case "Type":
                        if (string.IsNullOrEmpty(Type)) return "Тип вантажу обов'язковий";
                        if (!CargoTypeConverter.dictionary.ContainsValue(Type)) return "Обраний тип не підтримується";
                        break;
                }

                return default;
            }
        }
        public string Error => null;

        private static void UpdateStatus()
        {
            
        }
    }
}