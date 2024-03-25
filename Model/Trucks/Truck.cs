using System;

namespace TransDep_AdminApp.Trucks
{
    public abstract class Truck
    {
        protected string Name { get; set; }
        protected int[] CarryingCapacity { get; set; }
        protected int[] UsefulVolume { get; set; }
        protected int[] Capacity { get; set; }
        protected bool Availability { get; set; }

        public string getName => $"{Name}";
        public string getCarryingCapacity => $"{CarryingCapacity[0]}-{CarryingCapacity[1]}";
        public string getUsefulVolume => $"{UsefulVolume[0]}-{UsefulVolume[1]}";
        public string getCapacity => $"{Capacity[0]}-{Capacity[1]}";
        public string getAvailability => $"{(Availability ? "Вільна" : "На виклику")}";
        
        
        public override string ToString() => 
            $"{Name} : [ {CarryingCapacity[0]} ; {CarryingCapacity[1]} ] " +
            $"[ {UsefulVolume[0]} ; {UsefulVolume[1]} ] " +
            $"[ {Capacity[0]} ; {Capacity[1]} ]";
    }
}