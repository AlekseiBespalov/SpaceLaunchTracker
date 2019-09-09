using System;

namespace SpaceLaunchTracker.Data.ServiceModels
{
    public class LaunchModel
    {
        public int LaunchId { get; set; }
        public string MissionName { get; set; }
        public DateTime LaunchDate { get; set; }
        public string LaunchSite { get; set; }
        public string RocketName { get; set; }
        public string MissionDetails { get; set; }
        public string InfoUrl { get; set; }
        public DateTime ChangedTime { get; set; }

        public int AgencyId { get; set; }
        public string AgencyName { get; set; }
        public string AgencyInfoUrl { get; set; }

        public int CountryId { get; set; }
        public string CountryCode { get; set; }
    }
}
