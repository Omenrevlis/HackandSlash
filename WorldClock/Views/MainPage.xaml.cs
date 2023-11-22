using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.UI.Xaml.Controls;
using WorldClock.Models;
using WorldClock.ViewModels;
using Microsoft.UI.Xaml;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using WorldClock.Services;

namespace WorldClock.Views;

[ObservableObject]
public sealed partial class MainPage : Page
{
    public MainViewModel ViewModel
    {
        get;
    }

    public MainPage()
    {
        ViewModel = App.GetService<MainViewModel>();
        ViewModel.IconDataLoaded -= ViewModel_IconDataLoaded;
        ViewModel.IconDataLoaded += ViewModel_IconDataLoaded;
        InitializeComponent();
            
    }

    private void ViewModel_IconDataLoaded(object? sender, EventArgs e)
    {
        foreach (var item in ViewModel.FontIconData)
        {
            lvIcons.Items.Add(item);
        }
        //lvIcons.DataContext = ViewModel.FontIconData;
    }

}
