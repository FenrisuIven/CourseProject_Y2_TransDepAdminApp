using System;

namespace TransDep_AdminApp.Trucks
{
    public class Tent : Truck
    {
        //TODO: Check if those values are correct
        public static int[] allowedUsefulVolume = { 50, 90 };
        public static int[] allowedCarryingCapacity = { 50, 90 };
        public static int[] allowedCapacity = { 50, 90 };
        //TODO: ---------------------------------
        public Tent(string _name, int _carryingCapacity, int _usefulVolume, int _capacity, 
            bool _availability = true, int _id = 0) 
            : base(_id, _name, _carryingCapacity, _usefulVolume, _capacity, _availability)
        {
            ValidateData(_carryingCapacity, _usefulVolume, _capacity);
        }
        public void ValidateData(int carryingCapacity, int usefulVolume, int capacity)
        {
            if (carryingCapacity > allowedCarryingCapacity[1] || usefulVolume > allowedUsefulVolume[1] || capacity > allowedCapacity[1])
                throw new ArgumentOutOfRangeException(nameof(carryingCapacity),
                    @"One or more of the inputted characteristics were outside the upper limit set for this type.");
            
            if (carryingCapacity < allowedCarryingCapacity[0] || usefulVolume < allowedUsefulVolume[0] || capacity < allowedCapacity[0])
                throw new ArgumentOutOfRangeException(nameof(carryingCapacity),
                    @"One or more of the inputted characteristics were outside the lower limit set for this type.");
        }
    }
}