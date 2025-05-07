using System.Globalization;
using System.Windows.Data;

namespace Wpf.UserControlsExample.ControlsExample.GradientProgressBar.ControlNoumenon;

public class ProgressBarWidthConverter : IMultiValueConverter
{
    public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
    {
        if (values.Length != 3 || 
            !double.TryParse(values[0]?.ToString(), out double value) ||
            !double.TryParse(values[1]?.ToString(), out double maximum) ||
            !double.TryParse(values[2]?.ToString(), out double actualWidth))
        {
            return 0;
        }

        if (maximum <= 0 || actualWidth <= 0)
        {
            return 0;
        }

        return (value / maximum) * actualWidth;
    }

    public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}