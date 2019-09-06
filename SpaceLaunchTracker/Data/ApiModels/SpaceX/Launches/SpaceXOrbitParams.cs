using Newtonsoft.Json;

namespace LaunchAPIConsole.Data.ApiModels.SpaceX.Launches
{
    public class SpaceXOrbitParams
    {
        [JsonProperty(PropertyName = "reference_system")]
        public string ReferenceSystem { get; set; }

        public string Regime { get; set; }

        public object Longitude { get; set; }

        [JsonProperty(PropertyName = "semi_major_axis_km")]
        public object SemiMajorAxisKm { get; set; }

        public object Eccentricity { get; set; }

        [JsonProperty(PropertyName = "periapsis_km")]
        public object PeriapsisKm { get; set; }

        [JsonProperty(PropertyName = "apoapsis_km")]
        public object ApoapsisKm { get; set; }

        [JsonProperty(PropertyName = "inclination_deg")]
        public object InclinationDeg { get; set; }

        [JsonProperty(PropertyName = "period_min")]
        public object PeriodMin { get; set; }

        [JsonProperty(PropertyName = "lifespan_years")]
        public object LifespanYears { get; set; }

        public object Epoch { get; set; }

        [JsonProperty(PropertyName = "mean_motion")]
        public object MeanMotion { get; set; }

        public object Raan { get; set; }

        [JsonProperty(PropertyName = "arg_of_pericenter")]
        public object ArgOfPericenter { get; set; }

        [JsonProperty(PropertyName = "mean_anomaly")]
        public object MeanAnomaly { get; set; }
    }
}
