namespace TransDep_AdminApp
{
    public class Cargo
    {
        public double Weight { get; protected set; }
        public double Volume { get; protected set; }
        public CargoType Type { get; protected set; }

        public Cargo(double weight, double volume, CargoType type)
        {
            Weight = weight;
            Volume = volume;
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

    public enum CargoType
    {
        RequiresRefrigerator,
        DoesNotNeedRefrigerator
    }
}