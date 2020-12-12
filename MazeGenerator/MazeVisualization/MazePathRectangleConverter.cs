using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows.Data;
using MazeGenerator;

namespace MazeVisualization
{
    public class MazePathRectangleConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            MazeCell cell;
            string parsedParameter = parameter.ToString();
            double returnValue = 0;
            
            if (parsedParameter.ToLower() != "width" && parsedParameter.ToLower() != "height")
                throw new ArgumentException(nameof(parameter), "Invalid parameter");

            cell = value as MazeCell;

            if (cell == null)
                throw new ArgumentException(nameof(value), $"Value must be of type {typeof(MazeCell)}");

            bool isWalkDirectionVertical = cell.WalkDirection == Direction.Down || cell.WalkDirection == Direction.Up;
            bool isWalkDirectionHorizontal = cell.WalkDirection == Direction.Right || cell.WalkDirection == Direction.Left;

            if (isWalkDirectionHorizontal && parsedParameter.ToLower() == "width")
                returnValue = 7;
            else if (isWalkDirectionVertical && parsedParameter.ToLower() == "height")
                returnValue = 7;
            else
                returnValue = 2;

            return returnValue;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
