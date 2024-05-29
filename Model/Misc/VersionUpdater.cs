using System;
using System.Collections.Generic;
using System.Globalization;

namespace TransDep_AdminApp
{
    public class VersionUpdater
    {
        public static string GetCurrentVersion()
        {
            DateTimeFormatInfo dfi = DateTimeFormatInfo.CurrentInfo;
            Calendar cal = dfi.Calendar;

            int numOfWeek = cal.GetWeekOfYear(DateTime.Now, CalendarWeekRule.FirstDay, DayOfWeek.Monday);
            int numOfDay = cal.GetDayOfMonth(DateTime.Now);
            
            int gitPushNum = 23;        //Last Update: 29.05.2024, 22.51
            int countThisWeek = 5;      //Last Update: 29.05.2024  (skip 25 = z)
            char verChar = Convert.ToChar((countThisWeek % 26) + 97);
            
            return $"24{numOfWeek}{verChar}" + 
                   $"{(numOfDay < 10 ? $"0{numOfDay}" : $"{numOfDay}")}_" +
                   $"{(gitPushNum < 10 ? $"0{gitPushNum}" : $"{gitPushNum}")}";
        }
    }
}