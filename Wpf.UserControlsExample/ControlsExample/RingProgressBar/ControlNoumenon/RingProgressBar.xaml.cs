using System.Windows;
using System.Windows.Controls;

namespace Wpf.UserControlsExample.ControlsExample.RingProgressBar.ControlNoumenon;

public partial class RingProgressBar : UserControl
{
    public static readonly DependencyProperty ValueProperty =
        DependencyProperty.Register("Value", typeof(double), typeof(RingProgressBar), new PropertyMetadata(10.0));

   

    public double Value
    {
        get { return (double)GetValue(ValueProperty); }
        set { SetValue(ValueProperty, value); }
    }

    
    public RingProgressBar()
    {
        InitializeComponent();
    }
}