using Microsoft.UI.Xaml.Controls;

using WorldClock.ViewModels;

namespace WorldClock.Views;

public sealed partial class MapPage : Page
{
    public MapViewModel ViewModel
    {
        get;
    }

    public MapPage()
    {
        ViewModel = App.GetService<MapViewModel>();
        InitializeComponent();
    }
}
