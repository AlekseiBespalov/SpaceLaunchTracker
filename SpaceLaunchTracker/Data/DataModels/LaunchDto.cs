using System;

namespace SpaceLaunchTracker.Data.DataModels
{
    public class LaunchDto
    {
        public int Id { get; set; }
        public int LaunchNumber { get; set; }
        public string MissionName { get; set; } = "Unknown";
        public DateTime LaunchDate { get; set; }
        public string LaunchSite { get; set; }
        public string RocketName { get; set; }
        public string MissionDetails { get; set; }
        public string InfoUrl { get; set; }
        public DateTime ChangedTime { get; set; } // time when record was updated in API
        public DateTime UpdatedTime { get; set; } // time when record was updated in database
        
        public CountryDto Country { get; set; }

        public AgencyDto Agency { get; set; }
    }
}
