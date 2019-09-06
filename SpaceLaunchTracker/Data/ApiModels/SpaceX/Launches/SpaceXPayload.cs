using Newtonsoft.Json;

namespace LaunchAPIConsole.Data.ApiModels.SpaceX.Launches
{
    public class SpaceXPayload
    {
        [JsonProperty(PropertyName = "payload_Id")]
        public string PayloadId { get; set; }

        [JsonProperty(PropertyName = "norad_Id")]
        public object[] NoradId { get; set; }

        public bool Reused { get; set; }

        public string[] Customers { get; set; }

        public string Nationality { get; set; }

        public string Manufacturer { get; set; }

        [JsonProperty(PropertyName = "payload_type")]
        public string PayloadType { get; set; }

        [JsonProperty(PropertyName = "payload_mass_kg")]
        public float? PayloadMassKg { get; set; }

        [JsonProperty(PropertyName = "payload_mass_lbs")]
        public float? PayloadMassLbs { get; set; }

        public string Orbit { get; set; }

        [JsonProperty(PropertyName = "orbit_params")]
        public SpaceXOrbitParams OrbitParams { get; set; }
    }
}
