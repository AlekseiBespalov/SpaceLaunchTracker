using SpaceLaunchTracker.Data.DataModels;
using SpaceLaunchTracker.Data.Providers;
using SpaceLaunchTracker.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpaceLaunchTracker.Services
{
    public class LaunchService
    {
        private readonly ILaunchRepository _dbRepository;
        private readonly ILaunchProvider _provider;

        public LaunchService(ILaunchRepository dbRepository, ILaunchProvider provider)
        {
            _dbRepository = dbRepository;
            _provider = provider;
        }

        public async Task<List<LaunchDto>> GetLaunches()
        {
            List<LaunchDto> launches = await _dbRepository.GetAllLaunchesAsync();


            return launches;

            //to-do get launches timestamp from dbrepository
            //if timestamp+datalifetime <= datetime.now
            //{var launches = _provider.GetLaunches()
            //repo.addRangeLaunches(launches)}
            //

            //repo.GetLaunches
            //return 
        }
    }
}
