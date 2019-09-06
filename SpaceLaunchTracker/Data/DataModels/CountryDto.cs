using System.Collections.Generic;

namespace SpaceLaunchTracker.Data.DataModels
{
    public class CountryDto
    {
        public int Id { get; set; }
        public string CountryCode { get; set; }
        public ICollection<AgencyDto> Agencies { get; set; }
        public ICollection<LaunchDto> Launches { get; set; }
    }
}
