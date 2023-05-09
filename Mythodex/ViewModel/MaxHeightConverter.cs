using System;
using System.Globalization;
using System.Windows.Data;

namespace Mythodex.ViewModel
{
    public class MaxHeightConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            double windowHeight = (double)value;
            double maxHeight = windowHeight - (int)parameter;
            return maxHeight > 0 ? maxHeight : double.PositiveInfinity;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
