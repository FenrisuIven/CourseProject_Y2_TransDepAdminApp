using System;
using System.ComponentModel;
using TransDep_AdminApp.Enums;

namespace TransDep_AdminApp.ViewModel.Validation
{
    public class ValidationsFactory
    {
        public static IDataErrorInfo CreateTruckValidation(TruckType target)
        {
            switch (target)
            {
                case TruckType.AutoClutch: 
                    return new AutoClutchValidation();
                
                case TruckType.Container: 
                    return new AutoClutchValidation();
                
                case TruckType.Refrigerated: 
                    return new AutoClutchValidation();
                
                case TruckType.Tent: 
                    return new AutoClutchValidation();
            }
            return default;
        }
    }
}