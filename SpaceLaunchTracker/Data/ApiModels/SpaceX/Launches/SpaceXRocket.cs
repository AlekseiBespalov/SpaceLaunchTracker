using Newtonsoft.Json;

namespace LaunchAPIConsole.Data.ApiModels.SpaceX.Launches
{
    public class SpaceXRocket
    {
        [JsonProperty(PropertyName = "rocket_Id")]
        public string RocketId { get; set; }

        [JsonProperty(PropertyName = "rocket_name")]
        public string RocketName { get; set; }

        [JsonProperty(PropertyName = "rocket_type")]
        public string RocketType { get; set; }

        [JsonProperty(PropertyName = "first_stage")]
        public SpaceXFirstStage FirstStage { get; set; }

        [JsonProperty(PropertyName = "second_stage")]
        public SpaceXSecondStage SecondStage { get; set; }

        public SpaceXFairings Fairings { get; set; }
    }
}
