using Newtonsoft.Json;

namespace SpaceLaunchTracker.Data.ApiModels.LaunchLibrary.Launches
{
    public class LaunchLibraryAgency
    {
        [JsonProperty(PropertyName = "id")]
        public int AgencyId { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string AgencyName { get; set; }

        [JsonProperty(PropertyName = "abbrev")]
        public string Abbreviation { get; set; }

        [JsonProperty(PropertyName = "countryCode")]
        public string СountryCode { get; set; }

        public int Type { get; set; }

        public object InfoUrl { get; set; }

        public string WikiUrl { get; set; }

        public string Changed { get; set; }

        public string[] InfoUrls { get; set; }
    }
}
