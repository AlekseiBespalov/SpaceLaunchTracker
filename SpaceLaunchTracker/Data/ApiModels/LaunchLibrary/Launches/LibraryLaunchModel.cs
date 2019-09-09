using Newtonsoft.Json;
using System.Collections.Generic;

namespace SpaceLaunchTracker.Data.ApiModels.LaunchLibrary.Launches
{
    /// <summary>
    /// GET request
    /// https://launchlibrary.net/1.4/launch/{id}
    /// </summary>
    public class LibraryLaunchModel
    {
        [JsonProperty(PropertyName = "id")]
        public int LaunchId { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string LaunchName { get; set; }

        public string WindowStart { get; set; }

        public string WindowEnd { get; set; }

        [JsonProperty(PropertyName = "net")]
        public string LaunchTime { get; set; }

        public LaunchLibraryRocket Rocket { get; set; }

        public int Status { get; set; }

        public int TbdTime { get; set; }

        [JsonProperty(PropertyName = "vidURLs")]
        public string[] VidUrls { get; set; }

        public int TbdDate { get; set; }

        public int Probability { get; set; }

        public string Changed { get; set; }

        [JsonProperty(PropertyName = "infoURLs")]
        public string[] InfoUrls { get; set; }

        [JsonProperty(PropertyName = "infoURL")]
        public object InfoUrl { get; set; }

        public string FailReason { get; set; }

        [JsonProperty(PropertyName = "location")]
        public LaunchLibraryLocation Location { get; set; }

        public List<LaunchLibraryMission> Missions { get; set; }
    }
}
