using System;
using System.Windows.Media;

namespace TransDep_AdminApp
{
    public class ColorGenerator
    {
        private static Random rnd = new Random();
        public static Color GenerateRandom()
        {
            Func<int,int,double> getRndValue = (min, max) => rnd.Next(min,max);

            double amount = 220;
            
            int r = (int)(getRndValue(170, 256) * (getRndValue(200, 240) / 256));
            int g = (int)(getRndValue(150, 256) * (getRndValue(170, 200) / 256));
            int b = (int)(getRndValue(140, 180) * (getRndValue(190, 230) / 256));

            return Color.FromArgb(1, (byte)r, (byte)g, (byte)b);
        }
    }
}