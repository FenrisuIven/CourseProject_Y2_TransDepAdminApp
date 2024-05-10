using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Windows.Controls;
using Microsoft.Windows.Themes;

namespace TransDep_AdminApp.Model.View
{
    public class TruckValidation : IDataErrorInfo
    {
        public TruckType? Type { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public ComboBoxItem Quality { get; set; }

        public string this[string name]
        {
            get
            {
                switch (name)
                {
                    case "Brand":
                        if (string.IsNullOrEmpty(Brand)) return "Марка вантажівки обов'язкова";
                        break;
                    
                    case "Model":
                        if (string.IsNullOrEmpty(Model)) return "Модель вантажівки обов'язкова";
                        break;
                    
                    case "Type":
                        if (Type is null) return "11";
                        break;
                    
                    case "Quality":
                        if (Quality is null) return "Value is mandatory";
                        break;
                }

                return default;
            }
        }

        public string Error => null;
    }
}