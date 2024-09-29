using System;
using System.Globalization;

namespace Mythodex.ViewModel
{
    internal static class DateConverter
    {
        public static DateTime GetWeekDate(DateTime dateTime ,int i)
        {
            DateTime temp = dateTime;
            while (temp.DayOfWeek != DayOfWeek.Monday)
            {
                temp = temp.AddDays(-1);
            }
            return temp.AddDays(i-1);

        }
        public static string ConvertToSaveFormat(DateTime input)
        {
            return input.ToString("ddMMyyyy");
        }
    }
}
