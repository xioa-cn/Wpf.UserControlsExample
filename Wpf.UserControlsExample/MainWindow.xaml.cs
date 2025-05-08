﻿using System.Windows;
using System.Windows.Controls;
using Wpf.UserControlsExample.ViewModels;

namespace Wpf.UserControlsExample;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    private readonly MainViewModel mainViewModel;
    public MainWindow()
    {
        mainViewModel = new MainViewModel();
        this.DataContext = mainViewModel;
        InitializeComponent();
        this.Loaded += MainWindow_Loaded;
    }

    private void MainWindow_Loaded(object sender, RoutedEventArgs e)
    {
        dynamic item = mainViewModel.Content[0];
        if (item != null)
            if (item.e is Type t)
            {
                GoView(t);
            }
    }

    private Dictionary<string, object?> _data = new Dictionary<string, object?>();

    private void ContentGoonView(object sender, RoutedEventArgs e)
    {
        if ((sender as Button)?.Tag is not Type t) return;
        GoView(t);
    }

    private void GoView(Type t)
    {
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