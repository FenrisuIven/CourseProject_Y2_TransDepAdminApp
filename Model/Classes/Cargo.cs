namespace TransDep_AdminApp
{
    public class Cargo
    {
        public double Weight { get; set; }
        protected double Volume { get; set; }
        protected string Type { get; set; }

        public Cargo(double weight, double volume, string type)
        {
            Weight = weight;
            Volume = volume;
            Type = type;
        }
        
        public string WeightToString => $"{Weight} tons";
        public string VolumeToString => $"{Volume} m3";
        public string TypeToString => $"{Type}";
    }
}