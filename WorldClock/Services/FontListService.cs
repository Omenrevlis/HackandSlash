using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using WorldClock.Helpers;
using WorldClock.Contracts.Models;
using WorldClock.Models;
using System.Data;
using System.Security.Cryptography.X509Certificates;


namespace WorldClock.Services;
public class FontListService 
{
     
    public async Task<List<FontIconModel>> LoadIconData()
    {
        
        try
        {
            
            var iconDataStream = await GetAssetHelper.GetAssetStream("Assets", "IconsData.json");
            if (iconDataStream != null)
            {

                var options = new JsonSerializerOptions(JsonSerializerDefaults.General);

                var jsonList = await JsonSerializer.DeserializeAsync<List<FontIconModel>>(iconDataStream, options);
                if (jsonList != null)
                {
                    var sortedIcons = jsonList.OrderBy(x => x.Name).ToList();
                    return sortedIcons;
                }
                else { throw new JsonException("Failed to deserialize the IconData asset."); }

            }
            else { throw new IOException("Failed to load IconData asset."); }
        }
        catch (Exception ex)
        {
            //todo figure out logging
            throw new DataException("bad stuff happened here.", ex);
        }

    }
}
