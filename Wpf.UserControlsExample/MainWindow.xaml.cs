using System.Windows;
using System.Windows.Controls;
using Wpf.UserControlsExample.ViewModels;

namespace Wpf.UserControlsExample;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        this.DataContext = new MainViewModel();
        InitializeComponent();
    }

    private Dictionary<string, object?> _data = new Dictionary<string, object?>();

    private void ContentGoonView(object sender, RoutedEventArgs e)
    {
        if ((sender as Button)?.Tag is not Type t) return;
        if (t.FullName != null && _data.TryGetValue(t.FullName, out var value))
        {
            this.ContentControl.Content = value;
        }
        else
        {
            var obj = Activator.CreateInstance(t) as UserControl;

            this.ContentControl.Content = obj;
            if (t.FullName != null) _data[t.FullName] = obj;
        }
    }
}