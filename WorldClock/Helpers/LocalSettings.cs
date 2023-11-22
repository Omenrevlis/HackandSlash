using System.ComponentModel;
using Windows.Storage;

namespace WorldClock.Helpers;
[Description("LocalSetting is a singleton. Use LocalSettings.Instance to obtain a reference.")]
public sealed class LocalSettings
{
    private static readonly Lazy<LocalSettings> lazy = new(() => new LocalSettings());
    public static LocalSettings Instance => lazy.Value;

    static readonly ApplicationDataContainer settings = ApplicationData.Current.LocalSettings;


    private LocalSettings()
    {
    }

    public void writeSetting(string key, string value)
    {
        try
        {
            settings.Values[key] = value;
        }catch (Exception ex)
        {
            throw new InvalidDataException(string.Format("Failed to write LocalSettings. Key: {0} Value: {1}", key, value),ex);
        }
    }

    public string readSetting(string key)
    {
        try{

            if (settings.Values.ContainsKey(key))
            {
                return (string)settings.Values[key];
            }
            else { return string.Empty; }
        }
        catch(Exception ex)
        {
            throw new InvalidDataException(string.Format("Failed to load LocalSettings. Key: {0}", key), ex);
        }
    }

}
