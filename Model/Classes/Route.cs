using System;

namespace TransDep_AdminApp
{
    public class Route
    {
        private string Origin { get; set; }
        private string Destination { get; set; }

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

        public string GetRoute => $"{Origin} -- {Destination}";
    }
}