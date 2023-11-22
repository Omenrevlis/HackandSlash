using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.UI.Xaml;
using Windows.UI.Core;
using WorldClock.Models;
using WorldClock.Services;

namespace WorldClock.ViewModels;

public partial class MainViewModel : ObservableRecipient
{
    public event EventHandler? IconDataLoaded;
    public MainViewModel()
    {
        GetFonts();   
    }

    [ObservableProperty]
    private List<FontIconModel>? _fontIconData = new();

    //keep async void It allows the right context to get the the service
    //and it allows thie data to come back on the UI thread.
    //it's hacky, but for test it's good enough.
    private async void GetFonts()
    {
        try
        {
            var service = new FontListService();
            var data = await service.LoadIconData();
            FontIconData.AddRange(data);
            OnIconDataLoaded();
        }catch (Exception ex) 
        { 
        //todo figure out error logging.
        }
    }

    private void OnIconDataLoaded()
    {
        IconDataLoaded?.Invoke(this, EventArgs.Empty);
    }


}
