using Newtonsoft.Json;

namespace LaunchAPIConsole.Data.ApiModels.SpaceX.Launches
{
    public class SpaceXFairings
    {
        public bool Reused { get; set; }

        [JsonProperty(PropertyName = "recovery_attempt")]
        public bool? RecoveryAttempt { get; set; }

        public bool? Recovered { get; set; }

        public object Ship { get; set; }
    }
}
