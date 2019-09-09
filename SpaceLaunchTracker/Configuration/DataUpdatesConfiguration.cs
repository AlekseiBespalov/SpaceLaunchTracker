using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpaceLaunchTracker.Configuration
{
    public class DataUpdatesConfiguration
    {
        public DataUpdatesConfiguration()
        {
            DataLifetimeMinutes = 1440;
        }

        public int DataLifetimeMinutes { get; set; }
    }
}
