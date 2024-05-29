using System;

namespace TransDep_AdminApp.Model
{
    public class Route
    {
        public string Origin { get; private set; }
        public string Destination { get; private set; }

        public Route() {}
        public Route(string start, string finish)
        {
            Origin = start;
            Destination = finish;
        }

        public string GetTime() 
        {
            var rnd = new Random();
            int hours = rnd.Next(0, 3);
            int minutes = rnd.Next(0, 59);
            int seconds = rnd.Next(0, 59);
            return $"{hours}:{minutes}:{seconds}";
        }

        public string GetRoute() => $"{Origin} -- {Destination}";
    }
}