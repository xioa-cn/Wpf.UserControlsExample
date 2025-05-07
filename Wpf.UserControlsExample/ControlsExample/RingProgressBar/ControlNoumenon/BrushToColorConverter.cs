using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace Wpf.UserControlsExample.ControlsExample.RingProgressBar.ControlNoumenon;

public class BrushToColorConverter : IValueConverter
{
    public static Color GetColorFromBrush(Brush brush)
    {
        if (brush is SolidColorBrush solidColorBrush)
        {
            return solidColorBrush.Color;
        }
        else if (brush is LinearGradientBrush linearGradientBrush)
        {
            // 对于渐变刷，可以返回第一个颜色点的颜色
            return linearGradientBrush.GradientStops[0].Color;
        }
        else if (brush is RadialGradientBrush radialGradientBrush)
        {
            // 对于径向渐变刷，同样返回第一个颜色点的颜色
            return radialGradientBrush.GradientStops[0].Color;
        }

        // 如果都不是，返回默认颜色
        return Colors.Transparent;
    }

    public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        if (value is Brush brush)
            return GetColorFromBrush(brush);
        return Colors.Brown;
    }

    public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}