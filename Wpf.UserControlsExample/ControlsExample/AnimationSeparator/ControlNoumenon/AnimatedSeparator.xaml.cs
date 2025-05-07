using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace Wpf.UserControlsExample.ControlsExample.AnimationSeparator.ControlNoumenon;

public enum AnimationPoint
{
    /// <summary>
    /// 头
    /// </summary>
    Header,

    /// <summary>
    /// 尾
    /// </summary>
    Tail,
}

public partial class AnimatedSeparator : UserControl
{
    public static readonly DependencyProperty OrientationProperty =
        DependencyProperty.Register("Orientation", typeof(Orientation), typeof(AnimatedSeparator),
            new PropertyMetadata(Orientation.Horizontal, OnOrientationChanged));

    public static readonly DependencyProperty AnimationDurationProperty =
        DependencyProperty.Register("AnimationDuration", typeof(Duration), typeof(AnimatedSeparator),
            new PropertyMetadata(new Duration(TimeSpan.FromSeconds(10)), OnAnimationDurationChanged));

    public static readonly DependencyProperty AnimationPointProperty =
        DependencyProperty.Register("AnimationPoint", typeof(AnimationPoint), typeof(AnimatedSeparator),
            new PropertyMetadata(AnimationPoint.Header, OnAnimationPointPropertyChanged));

    private static void OnAnimationPointPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        var control = (AnimatedSeparator)d;
        control.UpdateAnimation();
    }

    private static void OnAnimationDurationChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        var control = (AnimatedSeparator)d;
        control.UpdateAnimation();
    }

    private void UpdateAnimation()
    {
        ChangeAnimations();
    }


    private void ChangeAnimations()
    {
        var border = (Border)Template.FindName("PART_Border", this);
        if (border == null) return;


        _animation.From = 0;
        _animation.To = this.Orientation == Orientation.Horizontal ? ActualWidth : ActualHeight;
        _animation.Duration = AnimationDuration;
        _animation.RepeatBehavior = RepeatBehavior.Forever;
        _animation.EasingFunction = new QuadraticEase() { EasingMode = EasingMode.EaseOut };

        border.BeginAnimation(this.Orientation == Orientation.Horizontal ? WidthProperty : HeightProperty,
            _animation);
        var grid = (Grid)Template.FindName("PART_Grid", this);
        if (grid == null) return;
        if (this.AnimationPoint == AnimationPoint.Header)
        {
            grid.RenderTransform = null;
        }
        else
        {
            var transform = new ScaleTransform();

            if (this.Orientation == Orientation.Horizontal)
                transform.ScaleX = -1;
            else
            {
                transform.ScaleY = -1;
            }


            grid.RenderTransform = transform;
        }
    }

    public Orientation Orientation
    {
        get => (Orientation)GetValue(OrientationProperty);
        set => SetValue(OrientationProperty, value);
    }

    public AnimationPoint AnimationPoint
    {
        get => (AnimationPoint)GetValue(AnimationPointProperty);
        set => SetValue(AnimationPointProperty, value);
    }


    public Duration AnimationDuration
    {
        get => (Duration)GetValue(AnimationDurationProperty);
        set => SetValue(AnimationDurationProperty, value);
    }

    public AnimatedSeparator()
    {
        this.SizeChanged += SizeChangedAniChange;
        InitializeComponent();
        UpdateTemplate();
    }

    private readonly DoubleAnimation _animation = new DoubleAnimation();

    private void SizeChangedAniChange(object sender, SizeChangedEventArgs e)
    {
        ChangeAnimations();
    }

    private static void OnOrientationChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        var control = (AnimatedSeparator)d;
        control.UpdateTemplate();
    }

    private void UpdateTemplate()
    {
        var templateKey = Orientation == Orientation.Horizontal
            ? "HorizontalTemplate"
            : "VerticalTemplate";

        Template = (ControlTemplate)FindResource(templateKey);
        ApplyTemplate();
    }
}