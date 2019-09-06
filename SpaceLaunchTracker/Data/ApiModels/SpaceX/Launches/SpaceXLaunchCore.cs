using Newtonsoft.Json;

namespace LaunchAPIConsole.Data.ApiModels.SpaceX.Launches
{
    public class SpaceXLaunchCore
    {
        [JsonProperty(PropertyName = "core_serial")]
        public object CoreSerial { get; set; }

        public object Flight { get; set; }

        public object Block { get; set; }

        public object Gridfins { get; set; }

        public object Legs { get; set; }

        public object Reused { get; set; }

        [JsonProperty(PropertyName = "and_success")]
        public object AndSuccess { get; set; }

        [JsonProperty(PropertyName = "landing_intent")]
        public object LandingIntent { get; set; }

        [JsonProperty(PropertyName = "landing_type")]
        public object LandingType { get; set; }

        [JsonProperty(PropertyName = "landing_vehicle")]
        public object LandingVehicle { get; set; }
    }
}
