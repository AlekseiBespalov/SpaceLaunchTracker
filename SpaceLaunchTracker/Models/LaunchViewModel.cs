using System;

namespace SpaceLaunchTracker.Models
{
    public class LaunchViewModel
    {
        public int LaunchId { get; set; }
        public int LaunchNumber { get; set; }
        public string MissionName { get; set; }
        public DateTime LaunchDate { get; set; }
        public string LaunchSite { get; set; }
        public string RocketName { get; set; }
        public string MissionDetails { get; set; }
        public string InfoUrl { get; set; }
        public DateTime ChangedTime { get; set; } // time when record was updated in API

    }
}
