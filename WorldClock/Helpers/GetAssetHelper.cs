
using Windows.ApplicationModel;

namespace WorldClock.Helpers;
public static class GetAssetHelper
{
    public static async Task<Stream?> GetAssetStream(string folderName, string assetFileNameWithExtension)
    {
        try
        {
            var installedLocationFolder = Package.Current.InstalledLocation;
            var assetsFolder = await installedLocationFolder.GetFolderAsync(folderName);
            var stream = await assetsFolder.OpenStreamForReadAsync(assetFileNameWithExtension);
            return stream;    
        }catch(Exception ex)
        {
            //Todo figure out error logging
            return null;
        }
    }

}
