using Flurl.Http;
using LaunchAPIConsole.Data.ApiModels.SpaceX.Launches;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

/// <summary>
/// Used SpaceX API v3 https://docs.spacexdata.com
/// </summary>
namespace SpaceLaunchTracker.Data.Clients
{
    public class SpaceXClient : ILaunchClient
    {
        private readonly string _allLaunchesLink = "https://api.spacexdata.com/v3/launches";
        private readonly string _upcomingLaunchesLink = "https://api.spacexdata.com/v3/launches/upcoming";

        public async Task <List<ExternalLaunchModel>> GetAllLaunches()
        {
            dynamic spaceXAllLaunchesJson = await _allLaunchesLink.GetJsonListAsync();
            string serializedJson = JsonConvert.SerializeObject(spaceXAllLaunchesJson);

            List<SpaceXLaunchModel> allSpaceXLaunches = JsonConvert.DeserializeObject<List<SpaceXLaunchModel>>(serializedJson);

            return ConvertToExternalLaunchModelList(allSpaceXLaunches);
        }

        public async Task<ExternalLaunchModel> GetLaunchById(int id)
        {
            string link = _allLaunchesLink + $"/{id}";
            dynamic spaceXAllLaunchesJson = await link.GetJsonAsync();
            string serializedJson = JsonConvert.SerializeObject(spaceXAllLaunchesJson);

            SpaceXLaunchModel SpaceXLaunch = JsonConvert.DeserializeObject<SpaceXLaunchModel>(serializedJson);

            return ConvertToExternalLaunchModel(SpaceXLaunch);
        }

        public async Task<List<ExternalLaunchModel>> GetUpcomingLaunches()
        {
            dynamic spaceXAllLaunchesJson = await _upcomingLaunchesLink.GetJsonListAsync();
            string serializedJson = JsonConvert.SerializeObject(spaceXAllLaunchesJson);

            List<SpaceXLaunchModel> allSpaceXLaunches = JsonConvert.DeserializeObject<List<SpaceXLaunchModel>>(serializedJson);

            return ConvertToExternalLaunchModelList(allSpaceXLaunches);
        }

        private ExternalLaunchModel ConvertToExternalLaunchModel(SpaceXLaunchModel spaceXLaunch)
        {
            ExternalLaunchModel launch = new ExternalLaunchModel
            {
                LaunchId = spaceXLaunch.FlightId,
                MissionName = spaceXLaunch.MissionName,

                LaunchDate = spaceXLaunch.LaunchDateUtc,
                LaunchSite = spaceXLaunch.LaunchSite.SiteName,
                RocketName = spaceXLaunch.Rocket.RocketName,
                MissionDetails = spaceXLaunch.Details,
                InfoUrl = spaceXLaunch.Links.Wikipedia,
                ChangedTime = DateTime.UtcNow,

                CountryId = 1,
                CountryCode = "USA",
                AgencyId = 1,
                AgencyName = "SpaceX"
            };

            return launch;
        }

        private List<ExternalLaunchModel> ConvertToExternalLaunchModelList(List<SpaceXLaunchModel> spaceXLaunches)
        {
            List<ExternalLaunchModel> launches = new List<ExternalLaunchModel>();
            foreach (SpaceXLaunchModel launch in spaceXLaunches)
            {
                ExternalLaunchModel externalLaunchModel = new ExternalLaunchModel
                {
                    LaunchId = launch.FlightId,
                    MissionName = launch.MissionName,

                    LaunchDate = launch.LaunchDateUtc,
                    LaunchSite = launch.LaunchSite.SiteName,
                    RocketName = launch.Rocket.RocketName,
                    MissionDetails = launch.Details,
                    InfoUrl = launch.Links.Wikipedia,
                    ChangedTime = DateTime.UtcNow,

                    CountryId = 1,
                    CountryCode = "USA",
                    AgencyId = 1,
                    AgencyName = "SpaceX"
                };

                launches.Add(externalLaunchModel);
            }

            return launches;
        }
    }
}
