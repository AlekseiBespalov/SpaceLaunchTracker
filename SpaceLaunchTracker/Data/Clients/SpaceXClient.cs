using Flurl.Http;
using LaunchAPIConsole.Data.ApiModels.SpaceX.Launches;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;

/// <summary>
/// Used SpaceX API v3 https://docs.spacexdata.com
/// </summary>
namespace SpaceLaunchTracker.Data.Clients
{
    public class SpaceXClient : ILaunchClient<SpaceXLaunchModel>
    {
        private readonly string _allLaunchesLink = "https://api.spacexdata.com/v3/launches";
        private readonly string _upcomingLaunchesLink = "https://api.spacexdata.com/v3/launches/upcoming";

        public async Task <List<SpaceXLaunchModel>> GetAllLaunches()
        {
            dynamic spaceXAllLaunchesJson = await _allLaunchesLink.GetJsonListAsync();
            string serializedJson = JsonConvert.SerializeObject(spaceXAllLaunchesJson);

            var allSpaceXLaunches = JsonConvert.DeserializeObject<List<SpaceXLaunchModel>>(serializedJson);

            return allSpaceXLaunches;
        }

        public async Task<SpaceXLaunchModel> GetLaunchById(int id)
        {
            string link = _allLaunchesLink + $"/{id}";
            dynamic spaceXAllLaunchesJson = await link.GetJsonAsync();
            string serializedJson = JsonConvert.SerializeObject(spaceXAllLaunchesJson);

            var spaceXLaunch = JsonConvert.DeserializeObject<SpaceXLaunchModel>(serializedJson);

            return spaceXLaunch;
        }

        public async Task<List<SpaceXLaunchModel>> GetUpcomingLaunches()
        {
            dynamic spaceXAllLaunchesJson = await _upcomingLaunchesLink.GetJsonListAsync();
            string serializedJson = JsonConvert.SerializeObject(spaceXAllLaunchesJson);

            var upcomingSpaceXLaunches = JsonConvert.DeserializeObject<List<SpaceXLaunchModel>>(serializedJson);

            return upcomingSpaceXLaunches;
        }
    }
}
