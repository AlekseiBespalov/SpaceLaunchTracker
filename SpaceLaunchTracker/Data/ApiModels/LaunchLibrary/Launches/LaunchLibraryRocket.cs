using Newtonsoft.Json;
using System.Collections.Generic;

namespace SpaceLaunchTracker.Data.ApiModels.LaunchLibrary.Launches
{
    public class LaunchLibraryRocket
    {
        [JsonProperty(PropertyName = "id")]
        public int RocketId { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string RocketName { get; set; }

        public string Configuration { get; set; }

        public string FamilyName { get; set; }

        public List<LaunchLibraryAgency> Agencies { get; set; }

        public int[] ImageSizes { get; set; }

        public string ImageURL { get; set; }

    }
}
