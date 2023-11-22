using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.UI.Xaml.Controls;

namespace WorldClock.Helpers;
public class WorldClockDataPersistedEventArgs:EventArgs
{
    public bool IsPersisted;

    
    public WorldClockDataPersistedEventArgs()
    {
    }

    public WorldClockDataPersistedEventArgs(bool isPersisted)
    {
        IsPersisted = isPersisted;
    }
}
