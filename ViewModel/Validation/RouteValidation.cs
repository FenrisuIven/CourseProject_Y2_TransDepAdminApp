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
                    
                }

                return null;
            }
        }
        public string Error { get; }
        
        public bool IsValid()
        {
            return true;
        }
    }
}