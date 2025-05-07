using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using Wpf.UserControlsExample.ControlsExample.AnimationSeparator.ControlNoumenon;

namespace Wpf.UserControlsExample.ControlsExample.AnimationSeparator;

public partial class UseExampleAutoTable : UserControl
{
    private ObservableCollection<AnimatedSeparator> AnimatedSeparators { get; set; } =
        new ObservableCollection<AnimatedSeparator>();

    public UseExampleAutoTable()
    {
        this.SizeChanged += SizeChangedAni;

        InitializeComponent();
        SeparatorItemsControl.ItemsSource = AnimatedSeparators;
    }

    private void SizeChangedAni(object sender, SizeChangedEventArgs e)
    {
        var normalMargin = 0;
    }
}