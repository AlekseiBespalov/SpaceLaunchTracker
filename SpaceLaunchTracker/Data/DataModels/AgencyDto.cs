using System.Collections.Generic;

namespace SpaceLaunchTracker.Data.DataModels
{
    public class AgencyDto
    {
        public int Id { get; set; }
        public string AgencyName { get; set; }
        public string InfoUrl { get; set; }
        public CountryDto Country { get; set; }
        public ICollection<LaunchDto> Launches { get; set; }
    }
}
