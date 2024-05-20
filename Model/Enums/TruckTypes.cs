using System.Collections.Generic;

namespace TransDep_AdminApp.Enums
{
    public enum TruckType
    {
        Refrigerated,
        Container,
        AutoClutch,
        Tent
    }

    public static class TruckTypeConvert
    {
        public static Dictionary<string, TruckType> dictionary = new() {
            {"Рефрижератор", TruckType.Refrigerated},
            {"Контейнеровіз", TruckType.Container},
            {"Автоцзепка", TruckType.AutoClutch},
            {"Тент", TruckType.Tent},
        };
    }
}