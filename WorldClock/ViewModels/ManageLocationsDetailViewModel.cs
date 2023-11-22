using CommunityToolkit.Mvvm.ComponentModel;

using WorldClock.Contracts.ViewModels;
using WorldClock.Core.Contracts.Services;
using WorldClock.Core.Models;

namespace WorldClock.ViewModels;

public partial class ManageLocationsDetailViewModel : ObservableRecipient, INavigationAware
{
    private readonly ISampleDataService _sampleDataService;

    [ObservableProperty]
    private SampleOrder? item;

    public ManageLocationsDetailViewModel(ISampleDataService sampleDataService)
    {
        _sampleDataService = sampleDataService;
    }

    public async void OnNavigatedTo(object parameter)
    {
        if (parameter is long orderID)
        {
            var data = await _sampleDataService.GetContentGridDataAsync();
            Item = data.First(i => i.OrderID == orderID);
        }
    }

    public void OnNavigatedFrom()
    {
    }
}
