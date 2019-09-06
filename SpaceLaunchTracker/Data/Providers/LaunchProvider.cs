using SpaceLaunchTracker.Data.Clients;
using SpaceLaunchTracker.Data.DataModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SpaceLaunchTracker.Data.Providers
{
    public class LaunchProvider : ILaunchProvider
    {
        private readonly ILaunchClient _client;

        public LaunchProvider(ILaunchClient client)
        {
            _client = client;
        }

        public Task<IList<LaunchDto>> GetAllLaunches()
        {
            throw new NotImplementedException();
        }

        public Task<LaunchDto> GetLaunchById()
        {
            throw new NotImplementedException();
        }
    }
}
