using Newtonsoft.Json;
using System.Collections.Generic;

namespace SpaceLaunchTracker.Data.ApiModels.LaunchLibrary.Launches
{
    public class LaunchLibraryMission
    {
        [JsonProperty(PropertyName = "id")]
        public int MissionId { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string MissionName { get; set; }

        [JsonProperty(PropertyName = "description")]
        public string MissionDescription { get; set; }

        [JsonProperty(PropertyName = "type")]
        public int MissionType { get; set; }

        public string WikiUrl { get; set; }

        public string TypeName { get; set; }

        public List<LaunchLibraryAgency> Agencies { get; set; }

        public List<LaunchLibraryPayload> Payloads { get; set; }
    }
}
