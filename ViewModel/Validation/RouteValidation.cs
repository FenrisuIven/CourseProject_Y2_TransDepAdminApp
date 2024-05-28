using System.ComponentModel;
using TransDep_AdminApp.Interfaces;

namespace TransDep_AdminApp.ViewModel.Validation
{
    public class RouteValidation : IDataErrorInfo, IValidationValid
    {
        public string StartPoint { get; set; }
        public string EndPoint { get; set; }
        public string this[string name]
        {
            get
            {
                switch (name)
                {
                    case "StartPoint":
                        if (string.IsNullOrEmpty(StartPoint)) return "Початок маршруту обов'язковий";
                        break;
                    case "EndPoint":
                        if (string.IsNullOrEmpty(EndPoint)) return "Кінець маршруту обов'язковий";
                        break;
                }

                return null;
            }
        }

        public string Error => null;
        
        public bool IsValid()
        {
            return true;
        }
    }
}