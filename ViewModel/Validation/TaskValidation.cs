using System.ComponentModel;
using System.Linq;
using TransDep_AdminApp.Interfaces;
using TransDep_AdminApp.ViewModel.DTO;

namespace TransDep_AdminApp.ViewModel.Validation
{
    public class TaskValidation : IDataErrorInfo, IValidationValid
    {
        public string Name { get; set; }
        public DriverDTO? Driver { get; set; }
        public TruckDTO? Truck { get; set; }
        public CargoValidation CargoVal { get; set; }
        public RouteValidation RouteVal { get; set; }

        public string this[string name]
        {
            get
            {
                switch (name)
                {
                    case "Name":
                        if (string.IsNullOrEmpty(Name)) return "Назва завдання обов'язкова";
                        break;
                    case "CargoVal":
                        if (!CargoVal.IsValid()) return "Error in Cargo Validation";
                        break;
                    case "RouteVal":
                        if (!RouteVal.IsValid()) return "Error in Route Validation";
                        break;
                    case "Driver":
                        if (Driver == null) return "Водій обов'язковий";
                        break;
                    case "Truck": 
                        if (Truck == null) return "Вантажівка обов'язкова";
                        break;
                }

                return default;
            }
        }
        public string Error => null;

        public bool IsValid() => 
            GetType().GetProperties()
            .Select(elem => elem.Name)
            .All(property => string.IsNullOrEmpty(this[property]));
    }
}