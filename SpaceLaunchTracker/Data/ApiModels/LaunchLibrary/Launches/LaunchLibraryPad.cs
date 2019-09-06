using Newtonsoft.Json;
using System.Collections.Generic;

namespace SpaceLaunchTracker.Data.ApiModels.LaunchLibrary.Launches
{
    public class LaunchLibraryPad
    {
        [JsonProperty(PropertyName = "id")]
        public int PadId { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string PadName { get; set; }

        public string InfoUrl { get; set; }

        public string WikiURL { get; set; }

        public string MapURL { get; set; }

        public double Latitude { get; set; }

        public double Longitude { get; set; }

        public List<LaunchLibraryAgency> Agencies { get; set; }
    }
}
