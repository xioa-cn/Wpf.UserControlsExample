using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace Wpf.UserControlsExample.ControlsExample.RingProgressBar.ControlNoumenon;

public class ProgressToPathConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        double progress = Math.Min(Math.Max((double)value, 0), 100);
        if (progress == 0) return null;

        if (progress == 100)
            return Geometry.Parse("M50,5 A45,45 0 1 1 50,95 A45,45 0 1 1 50,5");

        double angle = progress * 3.6; // 360 / 100 = 3.6
        double radians = (angle - 90) * Math.PI / 180.0;
            
        bool isLargeArc = progress > 50;
        double radius = 45;
            
        double endX = 50 + radius * Math.Cos(radians);
        double endY = 50 + radius * Math.Sin(radians);
            
        return Geometry.Parse(
            $"M50,5 A{radius},{radius} 0 {(isLargeArc ? 1 : 0)} 1 {endX},{endY}");
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}