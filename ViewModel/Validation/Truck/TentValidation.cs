using System.Linq;
using System.ComponentModel;
using TransDep_AdminApp.Model.Trucks;

namespace TransDep_AdminApp.ViewModel.Validation
{
    public class TentValidation : TruckCharsValidationBase, IDataErrorInfo
    {
        public TentValidation()
        {
            carryingCapacity = Tent.allowedCarryingCapacity;
            usefulVolume = Tent.allowedUsefulVolume;
            capacity = Tent.allowedCapacity;
        }
        public string this[string name]
        {
            get
            {
                switch (name)
                {
                    case "CarryingCapacity":
                        if (CarryingCapacity is null) return "Вантажопідйомність обов'язкова";
                        if (CarryingCapacity < carryingCapacity[0] || CarryingCapacity > carryingCapacity[1]) 
                            return $"Вантажопідйомність повинна бути у межах: [{carryingCapacity[0]} ; {carryingCapacity[1]}]";
                        break;
                    
                    case "UsefulVolume":
                        if (UsefulVolume is null) return "Корисний обсяг обов'язковий";
                        if (UsefulVolume < usefulVolume[0] || UsefulVolume > usefulVolume[1]) 
                            return $"Корисний обсяг повинен бути у межах: [{usefulVolume[0]} ; {usefulVolume[1]}]";
                        break;
                    
                    case "Capacity":
                        if (Capacity is null) return "Місткість обов'язкова";
                        if (Capacity < capacity[0] || Capacity > capacity[1]) 
                            return $"Місткість повинна бути у межах: [{capacity[0]} ; {capacity[1]}]";
                        break;
                }

                return default;
            }
        }

        public string Error => null;
        public override bool isValid() => 
            GetType().GetProperties()
                .Where(elem => ValidatedProps.Contains(elem.Name))
                .Select(elem => elem.Name)
                .All(elem => string.IsNullOrEmpty(this[elem]));
    }
}