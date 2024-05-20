using System.Collections.Generic;

namespace TransDep_AdminApp.Enums
{
    public enum CargoType
    {
        RequiresRefrigerator,
        DoesNotNeedRefrigerator
    }  
    public static class CargoTypeConverter
    {
        public static Dictionary<CargoType, string> dictionary = new() {
            {CargoType.RequiresRefrigerator, "Потребує холодильник"},
            {CargoType.DoesNotNeedRefrigerator, "Не потребує холодильника"},
        };
    }
}

