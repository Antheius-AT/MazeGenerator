using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows.Data;

namespace MazeVisualization
{
    public class CoordinateConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var isValid = int.TryParse(value.ToString(), out int converted);

            if (!isValid)
                throw new ArgumentException(nameof(value), "Value must be an an integer.");

            return converted * 7;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
