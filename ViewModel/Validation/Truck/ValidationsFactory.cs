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
                    return new ContainerValidation();
                
                case TruckType.Refrigerated: 
                    return new RefrigeratedValidation();
                
                case TruckType.Tent: 
                    return new TentValidation();
            }
            return default;
        }
    }
}