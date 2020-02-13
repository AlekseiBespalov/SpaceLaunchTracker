using System.Collections.Generic;

namespace SpaceLaunchTracker.Models
{
    public class CommonViewModel
    {
        public IEnumerable<CountryViewModel> Countries { get; set; }
        public IEnumerable<AgencyViewModel> Agencies { get; set; }
        public IEnumerable<LaunchViewModel> Launches { get; set; }
    }
}
