using System;
using System.Collections.Generic;
using System.Globalization;

namespace TransDep_AdminApp.Misc
{
    public class VersionUpdater
    {
        public static string GetCurrentVersion()
        {
            List<string> res = new List<string>();
            DateTimeFormatInfo dfi = DateTimeFormatInfo.CurrentInfo;
            Calendar cal = dfi.Calendar;

            int numOfWeek = cal.GetWeekOfYear(DateTime.Now, CalendarWeekRule.FirstDay, DayOfWeek.Monday);
            int numOfDay = cal.GetDayOfMonth(DateTime.Now);
            
<<<<<<< Updated upstream:Misc/VersionUpdater.cs
            int gitPushNum = 1;         //Last Update: 11.03.2024
            int countThisWeek = 1;      //Last Update: 11.03.2024 (skip 25 = z)
=======
            int gitPushNum = 2;         //Last Update: 11.03.2024
            int countThisWeek = 0;      //Last Update: 04.04.2024 (skip 25 = z)
>>>>>>> Stashed changes:Controller/Misc/VersionUpdater.cs
            char verChar = Convert.ToChar((countThisWeek % 26) + 97);
            
            return $"24{numOfWeek}{verChar}" + 
                   $"{(numOfDay < 10 ? $"0{numOfDay}" : $"{numOfDay}")}_" +
                   $"{(gitPushNum < 10 ? $"0{gitPushNum}" : $"{gitPushNum}")}";
        }
    }
}