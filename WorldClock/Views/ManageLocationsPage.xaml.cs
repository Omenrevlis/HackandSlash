using Microsoft.UI.Xaml.Controls;

using WorldClock.ViewModels;

namespace WorldClock.Views;

public sealed partial class ManageLocationsPage : Page
{
    public ManageLocationsViewModel ViewModel
    {
        get;
    }

    public ManageLocationsPage()
    {
        ViewModel = App.GetService<ManageLocationsViewModel>();
        InitializeComponent();
    }
}
