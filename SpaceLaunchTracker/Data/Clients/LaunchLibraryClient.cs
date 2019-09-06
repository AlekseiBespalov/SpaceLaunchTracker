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
    public class LaunchLibraryClient : ILaunchClient
    {
        private readonly string _allLaunchesLink = "https://launchlibrary.net/1.4/launch";
        private readonly string _upcomingLaunchesLink = "https://launchlibrary.net/1.4/launch?next=5";

        public async Task<List<ExternalLaunchModel>> GetAllLaunches()
        {
            dynamic launchLibraryAllLaunchesJson = await _allLaunchesLink.GetJsonAsync();
            string serializedJson = JsonConvert.SerializeObject(launchLibraryAllLaunchesJson);

            LaunchLibraryCollection launchCollection = JsonConvert.DeserializeObject<LaunchLibraryCollection>(serializedJson);

            return ConvertToExternalLaunchModelList(launchCollection);
        }

        public Task<ExternalLaunchModel> GetLaunchById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<ExternalLaunchModel>> GetUpcomingLaunches()
        {
            throw new NotImplementedException();
        }

        private List<ExternalLaunchModel> ConvertToExternalLaunchModelList(LaunchLibraryCollection launchCollection)
        {
            List<ExternalLaunchModel> launches = new List<ExternalLaunchModel>();
            foreach (LibraryLaunchModel launch in launchCollection.Launches)
            {
                ExternalLaunchModel externalLaunchModel = new ExternalLaunchModel
                {
                    LaunchId = launch.LaunchId,
                    MissionName = launch.LaunchName,

                    LaunchDate = DateTime.ParseExact(launch.LaunchTime, "MMMM dd, yyyy HH:mm:ss UTC", CultureInfo.InvariantCulture),
                    LaunchSite = launch.Location.LocationName,
                    RocketName = launch.Rocket.RocketName,
                    MissionDetails = launch.Missions[0].MissionName,
                    InfoUrl = launch.Missions[0].WikiUrl,
                    ChangedTime = DateTime.Parse(launch.Changed, CultureInfo.InvariantCulture),

                    //fix
                    //CountryId = 1,
                    //CountryCode = "USA",
                    //AgencyId = 1,
                    //AgencyName = "SpaceX"
                };

                launches.Add(externalLaunchModel);
            }

            return launches;
        }
    }
}
