using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Windows.Storage;

namespace WorldClock.Helpers;
public class LocalFileAccess
{

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE0059:Unnecessary assignment of a value", Justification = "Passing EX to inner exception")]
    public async Task<bool> SaveTextToFile(string filename, string contents)
    {
        try
        {
            if (!filename.ToLower().Contains(".json"))
            {
                filename += ".txt";
            }

            var localFolder = ApplicationData.Current.LocalFolder;
            
            var newFile = await localFolder.CreateFileAsync(filename,CreationCollisionOption.ReplaceExisting);
            await FileIO.WriteTextAsync(newFile, contents);

            return true;
            
        }catch (Exception ex)
        {
            //todo figure out error logging and perhaps be friendlier to the client using this and return a false.  Consider approach.
            return false;
            throw new IOException(string.Format("SaveTextToFile Failed to store text file with FileName: {0}",filename), ex);
            
        }
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE0059:Unnecessary assignment of a value", Justification = "Passing EX to inner exception")]
    public async Task<bool> SaveXmlToFile(string filenameWithoutPathOrExtension, XmlDocument contents)
    {
        try
        {
            var localFolder = ApplicationData.Current.LocalFolder;
            var newFile = await localFolder.CreateFileAsync(string.Format("{0}.txt", filenameWithoutPathOrExtension));
            await FileIO.WriteTextAsync(newFile, contents.OuterXml);
            return true;

        }
        catch (Exception ex)
        {
            //todo figure out error logging and perhaps be friendlier to the client using this and return a false.  Consider approach.
            return false;
            throw new IOException(string.Format("SaveTextToFile Failed to store XmlDocument with FileName: {0}", filenameWithoutPathOrExtension), ex);

        }
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE0059:Unnecessary assignment of a value", Justification = "Passing EX to inner exception")]
    public async Task<String> ReadTextFromFile(string filenameWithoutPathOrExtension)
    {
        try
        {
            if (!filenameWithoutPathOrExtension.ToLower().Contains(".json"))
            {
                filenameWithoutPathOrExtension += ".txt";
            }
            var localFolder = ApplicationData.Current.LocalFolder;
            var localFile = await localFolder.GetFileAsync(filenameWithoutPathOrExtension);
            if (localFile.IsAvailable) 
            {
                var fileContent = await FileIO.ReadTextAsync(localFile);
                return fileContent;
            }
            else { return string.Empty; }
        }
        catch (Exception ex)
        {
            //todo figure out error logging and perhaps be friendlier to the client using this and return a false.  Consider approach.
            return string.Empty;
            throw new IOException(string.Format("ReadTextFromFile Failed to load text file with FileName: {0}", filenameWithoutPathOrExtension), ex);
        }
    }

    
    public async Task<XmlDocument> ReadXmlFromFile(string filenameWithoutPathOrExtension)
    {
        try
        {
            var localFolder = ApplicationData.Current.LocalFolder;
            var localFile = await localFolder.GetFileAsync(string.Format("{0}.txt", filenameWithoutPathOrExtension));
            if (localFile.IsAvailable)
            {
                var fileContent = await FileIO.ReadTextAsync(localFile);
                var xdoc = new XmlDocument();
                xdoc.LoadXml(fileContent);
                return xdoc;
            }
        }
        catch (Exception ex)
        {
            //todo figure out error logging and perhaps be friendlier to the client using this and return a false.  Consider approach.
            throw new IOException(string.Format("ReadTextFromFile Failed to load text file with FileName: {0}", filenameWithoutPathOrExtension), ex);
        }
#pragma warning disable CS8603 // Possible null reference return.
        return null;
#pragma warning restore CS8603 // Possible null reference return.

    }
}
