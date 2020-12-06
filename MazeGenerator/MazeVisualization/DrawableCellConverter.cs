using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows.Data;
using MazeGenerator;

namespace MazeVisualization
{
    public class DrawableCellConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var valid = Enum.TryParse<Direction>(value.ToString(), out Direction converted);

            if (!valid)
                throw new ArgumentException(nameof(value), "Value must be a direction");

            switch (converted)
            {
                case Direction.None:
                    return "0, 0, 0, 0";
                case Direction.Up:
                    return "0, 0, 0, 0";
                case Direction.Down:
                    return "0, 0, 0, 0";
                case Direction.Left:
                    return "0, 0, 0, 0";
                case Direction.Right:
                    return "0, 0, 0, 0"; ;
                default:
                    throw new ArgumentException(nameof(value), "VAlue was invalid.");
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
