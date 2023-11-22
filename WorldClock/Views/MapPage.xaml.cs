using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.UI.Xaml.Controls;
using WorldClock.ViewModels;
using WorldClock.Contracts.Models;

namespace WorldClock.Views;

[ObservableObject]
public sealed partial class MapPage : Page
{
    public MainViewModel ViewModel
    {
        get;
    }

    public MapPage()
    {
        ViewModel = App.GetService<MainViewModel>();
        ViewModel.IconDataLoaded -= ViewModel_IconDataLoaded;
        ViewModel.IconDataLoaded += ViewModel_IconDataLoaded;
        InitializeComponent();
    }

    private void ViewModel_IconDataLoaded(object? sender, EventArgs e)
    {   //Commented out for pure data binding test

        //foreach (var item in ViewModel.FontIconData)
        //{
        //    lvIcons.Items.Add(item);
        //    exIcons.Items.Add(item);

        //}
        //lvIcons.ItemsSource = ViewModel.FontIconData;
        //exIcons.ItemsSource = ViewModel.FontIconData;
        //lvIcons.DataContext = ViewModel.FontIconData;
        //lvIcons.UpdateLayout();
    }
}
