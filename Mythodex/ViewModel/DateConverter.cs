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
            if (DateTime.TryParseExact(input.ToString(), "dd.MM.yyyy H:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime dateTime))
            {
                return dateTime.ToString("ddMMyyyyHHmmss");
            }

            return string.Empty;
        }

        public static string ConvertToDefaultFormat(DateTime input)
        {
            if (DateTime.TryParseExact(input.ToString(), "ddMMyyyyHHmmss", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime dateTime))
            {
                return dateTime.ToString("dd.MM.yyyy H:mm:ss");
            }

            return string.Empty;
        }
    }
}
