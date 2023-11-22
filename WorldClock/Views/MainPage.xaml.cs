using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.UI.Xaml.Controls;
using WorldClock.ViewModels;
using WorldClock.Contracts.Models;
using WorldClock.Models;

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

    private void lstexpander_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        var item = lstexpander.SelectedItem as FontIconModel;
        exSelectedIcon.Glyph = item.FontCode.ToString();
    }



   
   


}
