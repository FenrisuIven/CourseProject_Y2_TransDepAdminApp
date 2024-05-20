using System;
using System.Text;

namespace TransDep_AdminApp
{
    public static class IDGenerator
    {
        public static string GenerateRandom(int length = 8)
        {
            var sb = new StringBuilder();
            int amountOfGuids = ((length - 1) / 8) + 1;
            for (int i = 0; i < amountOfGuids; i++)
            {
                sb.Append(Guid.NewGuid().ToString("D").Split(new[] {'-'})[0]);
            }
            return sb.ToString(0, length);
        }
    }
}