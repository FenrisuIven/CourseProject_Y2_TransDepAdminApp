using System.ComponentModel;
using TransDep_AdminApp.Interfaces;

namespace TransDep_AdminApp.ViewModel.Validation
{
    public class RouteValidation : IDataErrorInfo, IValidationValid
    {
        public string this[string columnName] => throw new System.NotImplementedException();
        public string Error { get; }
        
        public bool IsValid()
        {
            return true;
        }
    }
}