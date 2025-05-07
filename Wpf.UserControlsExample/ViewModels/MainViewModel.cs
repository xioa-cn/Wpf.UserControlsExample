using System.Reflection;

namespace Wpf.UserControlsExample.ViewModels;

public class MainViewModel
{
    public List<object?> Content { get; set; } = new();

    public MainViewModel()
    {
        Assembly.Load("Wpf.UserControlsExample")
            .GetTypes()
            .Where(e => e.FullName != null && e.FullName.Contains("UseExample"))
            .Select(e => new { e, Name = e.FullName.Split('.')[3] }).ToList()
            .ForEach(e => this.Content.Add(e));
    }
}