using Flurl.Http;
using Newtonsoft.Json;
using SpaceLaunchTracker.Data.ApiModels.LaunchLibrary.Launches;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

/// <summary>
/// Used Launch Library API https://launchlibrary.net/docs/1.4.1/
/// </summary>
namespace SpaceLaunchTracker.Data.Clients
{
    public class LaunchLibraryClient : ILaunchClient<LibraryLaunchModel>
    {
        private readonly string _allLaunchesLink = "https://launchlibrary.net/1.4/launch";
        private readonly string _upcomingLaunchesLink = "https://launchlibrary.net/1.4/launch/next/5";

        public async Task<List<LibraryLaunchModel>> GetAllLaunches()
        {
            dynamic launchLibraryAllLaunchesJson = await _allLaunchesLink.GetJsonAsync();
            string serializedJson = JsonConvert.SerializeObject(launchLibraryAllLaunchesJson, Formatting.Indented,
                new JsonSerializerSettings{NullValueHandling = NullValueHandling.Ignore});

            var launchCollection = JsonConvert.DeserializeObject<LaunchLibraryCollection>(serializedJson);

            var launches = new List<LibraryLaunchModel>();
            launches.AddRange(launchCollection.Launches);

            return launches;
        }

        public async Task<LibraryLaunchModel> GetLaunchById(int id)
        {
            var link = _allLaunchesLink + $"/{id}";
            dynamic launchLibraryAllLaunchesJson = await link.GetJsonAsync();
            string serializedJson = JsonConvert.SerializeObject(launchLibraryAllLaunchesJson);

            var launchCollection = JsonConvert.DeserializeObject<LaunchLibraryCollection>(serializedJson);

            var launches = new List<LibraryLaunchModel>();
            launches.AddRange(launchCollection.Launches);

            //return first record from api because there is always launches array
            return launches[0];
        }

        public async Task<List<LibraryLaunchModel>> GetUpcomingLaunches()
        {
            dynamic launchLibraryLaunchesJson = await _upcomingLaunchesLink.GetJsonAsync();
            string serializedJson = JsonConvert.SerializeObject(launchLibraryLaunchesJson, Formatting.Indented,
                new JsonSerializerSettings{NullValueHandling = NullValueHandling.Ignore});

            var launchCollection = JsonConvert.DeserializeObject<LaunchLibraryCollection>(serializedJson);

            var launches = new List<LibraryLaunchModel>();
            launches.AddRange(launchCollection.Launches);

            return launches;
        }
    }
}
