using System;
using System.Collections.Generic;
using System.Globalization;

namespace TransDep_AdminApp
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
            
            int gitPushNum = 1;         //Last Update: 11.03.2024
            int countThisWeek = 0;      //Last Update: 25.03.2024 (skip 25 = z)
            char verChar = Convert.ToChar((countThisWeek % 26) + 97);
            
            return $"23{numOfWeek}{verChar}" + 
                   $"{(numOfDay < 10 ? $"0{numOfDay}" : $"{numOfDay}")}_" +
                   $"{(gitPushNum < 10 ? $"0{gitPushNum}" : $"{gitPushNum}")}";
        }
    }
}