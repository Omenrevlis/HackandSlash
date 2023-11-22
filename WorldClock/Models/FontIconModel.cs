using CommunityToolkit.Mvvm.ComponentModel;
using WorldClock.Contracts.Models;

namespace WorldClock.Models;
[ObservableObject]
public partial class FontIconModel : IFontIconModel
{
    [ObservableProperty]
    private string _HexCode;

    [ObservableProperty]
    private string _Name;

    [ObservableProperty]
    private char _FontCode;

}
