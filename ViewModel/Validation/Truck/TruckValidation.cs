using System.ComponentModel;
using System.Windows.Controls;
using TransDep_AdminApp.Enums;
using TransDep_AdminApp.Interfaces;

namespace TransDep_AdminApp.ViewModel.Validation
{
    public class TruckValidation : IDataErrorInfo
    {
        public TruckType? Type { get; set; }
        public string Name { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public ComboBoxItem Quality { get; set; }
        
        // TODO: IsValid() to check if all fields are valid
        
        public string this[string name]
        {
            get
            {
                switch (name)
                {
                    case "Name":
                        if (MultipleNamesCheck() != null) return MultipleNamesCheck();
                        if (string.IsNullOrEmpty(Name) && string.IsNullOrEmpty(Model) && string.IsNullOrEmpty(Brand)) return "Назва (або Марка та Модель) обов'язкова";
                        break;
                    
                    case "Brand":
                        if (MultipleNamesCheck() != null) return MultipleNamesCheck();
                        if (BrandModelNameCheck() != null) return BrandModelNameCheck();
                        break;
                    
                    case "Model":
                        if (MultipleNamesCheck() != null) return MultipleNamesCheck();
                        if (BrandModelNameCheck() != null) return BrandModelNameCheck();
                        break;
                    
                    case "Type":
                        if (Type is null) return "Тип вантажівки обов'язковий";
                        break;
                    
                    case "Quality":
                        if (Quality is null) return "Технічний стан обов'язковий";
                        break;
                }

                return default;
            }
        }

        private string MultipleNamesCheck()
        {
            if (!string.IsNullOrEmpty(Name) && !string.IsNullOrEmpty(Model) && !string.IsNullOrEmpty(Brand)) return "Потрібна лише Назва або лише Марка та Модель";
            if (!string.IsNullOrEmpty(Name) && !string.IsNullOrEmpty(Model)) return "Потрібна лише Назва або лише Марка та Модель";
            if (!string.IsNullOrEmpty(Name) && !string.IsNullOrEmpty(Brand)) return "Потрібна лише Назва або лише Марка та Модель";

            return default;
        }

        private string BrandModelNameCheck()
        {
            if (string.IsNullOrEmpty(Brand) && !string.IsNullOrEmpty(Model)) return "Марка та Модель (або Назва) вантажівки обов'язкова";
            if (!string.IsNullOrEmpty(Brand) && string.IsNullOrEmpty(Model)) return "Марка та Модель (або Назва) вантажівки обов'язкова";
            
            return default;
        }
        
        public string Error => null;
    }
}