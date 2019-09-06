using Newtonsoft.Json;
using System;

namespace LaunchAPIConsole.Data.ApiModels.SpaceX.Launches
{
    /// <summary>
    /// GET request for getting one launch
    /// https://api.spacexdata.com/v3/launches/{{flight_number}}
    /// </summary>
    public class SpaceXLaunchModel
    {
        [JsonProperty(PropertyName = "flight_number")]
        public int FlightId { get; set; }

        [JsonProperty(PropertyName = "mission_name")]
        public string MissionName { get; set; }

        [JsonProperty(PropertyName = "mission_id")]
        public object[] MissionId { get; set; }

        [JsonProperty(PropertyName = "launch_year")]
        public string LaunchYear { get; set; }

        [JsonProperty(PropertyName = "launch_date_unix")]
        public int LaunchDateUnix { get; set; }

        [JsonProperty(PropertyName = "launch_date_utc")]
        public DateTime LaunchDateUtc { get; set; }

        [JsonProperty(PropertyName = "launch_date_local")]
        public DateTime LaunchDateLocal { get; set; }

        [JsonProperty(PropertyName = "is_tentative")]
        public bool IsTentative { get; set; }

        [JsonProperty(PropertyName = "tentative_max_precision")]
        public string TentativeMaxPrecision { get; set; }

        [JsonProperty(PropertyName = "tbd")]
        public bool Tbd { get; set; }

        [JsonProperty(PropertyName = "launch_window")]
        public object LaunchWindow { get; set; }

        public SpaceXRocket Rocket { get; set; }

        public object[] Ships { get; set; }

        [JsonProperty(PropertyName = "launch_site")]
        public SpaceXLaunchSite LaunchSite { get; set; }

        [JsonProperty(PropertyName = "launch_success")]
        public object LaunchSuccess { get; set; }

        public SpaceXLinks Links { get; set; }

        public string Details { get; set; }

        public bool Upcoming { get; set; }

        [JsonProperty(PropertyName = "static_fire_date_utc")]
        public object StaticFireDateUtc { get; set; }

        [JsonProperty(PropertyName = "static_fire_date_unix")]
        public object StaticFireDateUnix { get; set; }

        public object Timeline { get; set; }

        public object Crew { get; set; }
    }
}
