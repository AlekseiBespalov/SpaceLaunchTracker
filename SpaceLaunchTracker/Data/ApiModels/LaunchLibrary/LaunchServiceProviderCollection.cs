using System.Collections.Generic;

namespace SpaceLaunchTracker.Data.ApiModels.LaunchLibrary
{
    public class LaunchServiceProviderCollection
    {
        public List<LaunchServiceProvider> Agencies { get; set; }

        public int Total { get; set; }

        public int Count { get; set; }

        public int Offset { get; set; }
    }
}
