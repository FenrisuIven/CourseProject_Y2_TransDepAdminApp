using System;

namespace TransDep_AdminApp
{
    public abstract class Truck
    {
        public int Id { get; protected set; }
        public string Name { get; protected set; }
        public int CarryingCapacity { get; protected set; }
        public int UsefulVolume { get; protected set; }
        public int Capacity { get; protected set; }
        public bool Availability { get; protected set; }
        
        protected int[] allowedCarryingCapacity;
        protected int[] allowedUsefulVolume;
        protected int[] allowedCapacity;

        protected void Check(int carryingCapacity, int usefulVolume, int capacity)
        {
            if (carryingCapacity > allowedCarryingCapacity[1] || usefulVolume > allowedUsefulVolume[1] || capacity > allowedCapacity[1])
                throw new ArgumentOutOfRangeException(nameof(carryingCapacity),
                    @"One or more of the inputted characteristics were outside the upper limit set for this type.");
            
            if (carryingCapacity < allowedCarryingCapacity[0] || usefulVolume < allowedUsefulVolume[0] || capacity < allowedCapacity[0])
                throw new ArgumentOutOfRangeException(nameof(carryingCapacity),
                    @"One or more of the inputted characteristics were outside the lower limit set for this type.");
        }
        
        public string stringName() => $"{Name}";
        public string stringCarryingCapacity() => $"{CarryingCapacity}";
        public string stringUsefulVolume() => $"{UsefulVolume}";
        public string stringCapacity() => $"{Capacity}";
        public string stringAvailability() => $"{(Availability ? "Вільна" : "На виклику")}";
        
        public string stringAllowedUsefulVolume() => $"{allowedUsefulVolume[0]}-{allowedUsefulVolume[1]}"; 
        
        public override string ToString() => 
            $"{Name} : [ {CarryingCapacity} ] " +
            $"[ {UsefulVolume} ] " +
            $"[ {Capacity} ]";
    }
}