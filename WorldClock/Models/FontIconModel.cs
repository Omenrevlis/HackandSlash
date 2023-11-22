using System.Globalization;
using CommunityToolkit.Mvvm.ComponentModel;
using WorldClock.Contracts.Models;

namespace WorldClock.Models;
[ObservableObject]
public partial class FontIconModel : IFontIconModel
{
    [ObservableProperty]
    private string _Code;

    [ObservableProperty]
    private string _Name;

    public char FontCode
    {
        get
        {
            var iconChar = (char)int.Parse(Code, NumberStyles.HexNumber);
            return iconChar;
        }
    }
}
