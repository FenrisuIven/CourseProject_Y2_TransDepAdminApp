using System.Linq;

namespace TransDep_AdminApp.ViewModel.Validation
{
    public class TruckCharsValidationBase
    {
        protected double[] carryingCapacity;
        protected double[] usefulVolume;
        protected double[] capacity;
        public int? CarryingCapacity { get; set; }
        public int? UsefulVolume { get; set; }
        public int? Capacity { get; set; }

        protected string[] ValidatedProps = { "CarryingCapacity", "UsefulVolume", "Capacity" };

        private string Check(string name)
        {
            switch (name)
            {
                case "CarryingCapacity":
                    if (CarryingCapacity is null) return "empty";
                    break;
                case "UsefulVolume":
                    if (UsefulVolume is null) return "empty";
                    break;
                case "Capacity":
                    if (Capacity is null) return "empty";
                    break;
            }
            
            return default;
        }
        public virtual bool isValid() => 
            GetType().GetProperties()
            .Where(elem => ValidatedProps.Contains(elem.Name))
            .Select(elem => elem.Name)
            .All(elem => string.IsNullOrEmpty(Check(elem)));
    }
}