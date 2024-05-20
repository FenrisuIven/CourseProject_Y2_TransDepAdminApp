using TransDep_AdminApp.Enums;

namespace TransDep_AdminApp.Model
{
    public class Cargo
    {
        public double Weight { get; protected set; }
        public double Volume { get; protected set; }
        public double Amount { get; protected set; }
        public CargoType Type { get; protected set; }

        public Cargo(double weight, double volume, double amount, CargoType type)
        {
            Weight = weight;
            Volume = volume;
            Amount = amount;
            Type = type;
        }
        
        public string WeightToString() => $"{Weight} tons";
        public string VolumeToString() => $"{Volume} m3";
        public string TypeToString() => $"{Type}";
        public override string ToString()
        {
            return $"{Weight} tons, {Volume} m3, {Type}";
        }
    }

    
}