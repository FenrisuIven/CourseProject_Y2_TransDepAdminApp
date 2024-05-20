using System.ComponentModel;
using System.Net.Configuration;
using TransDep_AdminApp.Model.Trucks;

namespace TransDep_AdminApp.ViewModel.Validation
{
    public class AutoClutchValidation : IDataErrorInfo
    {
        private double[] carryingCapacity = AutomaticClutch.allowedCarryingCapacity;
        private double[] capacity = AutomaticClutch.allowedCapacity;
        private double[] usefulVolume = AutomaticClutch.allowedUsefulVolume;
        public int? CarryingCapacity { get; set; }
        public int? UsefulVolume { get; set; }
        public int? Capacity { get; set; }
        
        public string this[string name]
        {
            get
            {
                switch (name)
                {
                    case "CarryingCapacity":
                        if (CarryingCapacity < carryingCapacity[0] || CarryingCapacity > carryingCapacity[1]) 
                            return $"Вантажопідйомність повинна бути у межах: [{carryingCapacity[0]} ; {carryingCapacity[1]}]";
                        if (string.IsNullOrEmpty(CarryingCapacity.ToString()))
                            return "Вантажопідйомність обов'язкова";
                        break;
                    
                    case "UsefulVolume":
                        if (UsefulVolume < usefulVolume[0] || UsefulVolume > usefulVolume[1]) 
                            return $"Корисний обсяг повинен бути у межах: [{usefulVolume[0]} ; {usefulVolume[1]}]";
                        if (string.IsNullOrEmpty(UsefulVolume.ToString()))
                            return "Корисний обсяг обов'язковий";
                        break;
                    
                    case "Capacity":
                        if (Capacity < capacity[0] || Capacity > capacity[1]) 
                            return $"Місткість повинна бути у межах: [{capacity[0]} ; {capacity[1]}]";
                        if (string.IsNullOrEmpty(Capacity.ToString()))
                            return "Місткість обов'язкова";
                        break;
                }

                return default;
            }
        }

        public string Error => null;
    }
}