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
    private Random random = new Random();
    private void SizeChangedAni(object sender, SizeChangedEventArgs e)
    {
        var aHeight = this.ActualHeight;
        var aWidth = this.ActualWidth;
        var havingAniSeparatorsVo = aHeight / 20;
        var havingAniSeparatorsHo = aWidth / 20;

        var left = (aWidth - havingAniSeparatorsHo * 20) / 2;
        var top = (aHeight - havingAniSeparatorsVo * 20) / 2;

        var margin = new Thickness(left, top, left, top);
        SeparatorItemsControl.Margin = margin;

        AnimatedSeparators.Clear();

        Enumerable.Range(0, (int)havingAniSeparatorsVo + 1).ToList().ForEach(item =>
        {
            AnimatedSeparators.Add(new AnimatedSeparator()
            {
                Margin = new Thickness(20,top+item * 20,20,0),
                Orientation =  Orientation.Horizontal,
                VerticalAlignment = VerticalAlignment.Top,
                AnimationDuration = new  Duration(TimeSpan.FromSeconds(random.Next(5,10)))
            });
            
            AnimatedSeparators.Add(new AnimatedSeparator()
            {
                Margin = new Thickness(20,top+item * 20,20,0),
                Orientation =  Orientation.Horizontal,
                VerticalAlignment = VerticalAlignment.Top,
                AnimationPoint = AnimationPoint.Tail,
                AnimationDuration = new  Duration(TimeSpan.FromSeconds(random.Next(5,10)))
            });
        });
        
        Enumerable.Range(0, (int)havingAniSeparatorsHo + 1).ToList().ForEach(item =>
        {
            AnimatedSeparators.Add(new AnimatedSeparator()
            {
                Margin = new Thickness(20+left+item * 20,0,20,0),
                Orientation =  Orientation.Vertical,
                HorizontalAlignment = HorizontalAlignment.Left,
                AnimationDuration = new  Duration(TimeSpan.FromSeconds(random.Next(5,10)))
            });
            
            AnimatedSeparators.Add(new AnimatedSeparator()
            {
                Margin = new Thickness(20+left+item * 20,0,20,0),
                Orientation =  Orientation.Vertical,
                HorizontalAlignment = HorizontalAlignment.Left,
                AnimationPoint = AnimationPoint.Tail,
                AnimationDuration = new  Duration(TimeSpan.FromSeconds(random.Next(5,10)))
            });
        });
    }
}