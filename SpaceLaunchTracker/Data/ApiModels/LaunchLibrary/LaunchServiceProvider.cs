using Newtonsoft.Json;
using System.Collections.Generic;

namespace SpaceLaunchTracker.Data.ApiModels.LaunchLibrary
{
    /// <summary>
    /// GET request
    /// https://launchlibrary.net/1.4/lsp
    /// </summary>
    public class LaunchServiceProvider
    {
        [JsonProperty(PropertyName = "id")]
        public int ProviderId { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string ProviderName { get; set; }

        [JsonProperty(PropertyName = "countryCode")]
        public string СountryCode { get; set; }

        [JsonProperty(PropertyName = "abbrev")]
        public string Abbreviation { get; set; }

        public int Type { get; set; }

        public string InfoUrl { get; set; }

        public string WikiUrl { get; set; }

        public List<object> InfoUrls { get; set; }

        public int IsLsp { get; set; }

        public string Changed { get; set; }
    }
}
