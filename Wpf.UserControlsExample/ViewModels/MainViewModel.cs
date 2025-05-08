using System.Reflection;
using System.Windows.Controls;

namespace Wpf.UserControlsExample.ViewModels;

public class MainViewModel
{
    public List<object?> Content { get; set; } = new();

    public MainViewModel()
    {
        var types = Assembly.Load("Wpf.UserControlsExample")
            .GetTypes()
            .Where(e => e.BaseType == typeof(UserControl) && e.FullName != null && e.FullName.Contains("UseExample"))
            .ToList();
        types.Select(e => new { e, Name = e.FullName.Split('.')[3] }).ToList()
            .ForEach(e => this.Content.Add(e));
    }
}