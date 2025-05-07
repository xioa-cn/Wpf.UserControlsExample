using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Wpf.UserControlsExample.ControlsExample.GradientProgressBar.ControlNoumenon;

public partial class GradientProgressBar : UserControl
{
    public static readonly DependencyProperty ValueProperty =
        DependencyProperty.Register("Value", typeof(double), typeof(GradientProgressBar), new PropertyMetadata(0.0));

    public static readonly DependencyProperty LabelProperty =
        DependencyProperty.Register("Label", typeof(string), typeof(GradientProgressBar), new PropertyMetadata(string.Empty));

    public static readonly DependencyProperty StartColorProperty =
        DependencyProperty.Register("StartColor", typeof(Color), typeof(GradientProgressBar), new PropertyMetadata(Colors.Blue));

    public static readonly DependencyProperty EndColorProperty =
        DependencyProperty.Register("EndColor", typeof(Color), typeof(GradientProgressBar), new PropertyMetadata(Colors.Blue));

    public double Value
    {
        get { return (double)GetValue(ValueProperty); }
        set { SetValue(ValueProperty, value); }
    }

    public string Label
    {
        get { return (string)GetValue(LabelProperty); }
        set { SetValue(LabelProperty, value); }
    }

    public Color StartColor
    {
        get { return (Color)GetValue(StartColorProperty); }
        set { SetValue(StartColorProperty, value); }
    }

    public Color EndColor
    {
        get { return (Color)GetValue(EndColorProperty); }
        set { SetValue(EndColorProperty, value); }
    }

    public GradientProgressBar()
    {
        InitializeComponent();
    }
}