using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpaceLaunchTracker.Models
{
    public class CommonViewModel
    {
        public IEnumerable<CountryViewModel> Countries { get; set; }
        public IEnumerable<AgencyViewModel> Agencies { get; set; }
        public IEnumerable<LaunchViewModel> Launches { get; set; }
    }
}
