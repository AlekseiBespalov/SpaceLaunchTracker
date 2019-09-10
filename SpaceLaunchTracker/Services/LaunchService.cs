using SpaceLaunchTracker.Data.DataModels;
using SpaceLaunchTracker.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Channels;
using System.Threading.Tasks;
using AutoMapper;
using SpaceLaunchTracker.Models;

namespace SpaceLaunchTracker.Services
{
    public class LaunchService
    {
        private readonly ILaunchRepository _dbRepository;
        private readonly IMapper _mapper;

        public LaunchService(ILaunchRepository dbRepository, IMapper mapper)
        {
            _dbRepository = dbRepository;
            _mapper = mapper;
        }

        public async Task<List<LaunchViewModel>> GetLAllLaunches()
        {
            List<LaunchDto> launches = await _dbRepository.GetAllLaunchesAsync();


            return _mapper.Map<List<LaunchViewModel>>(launches);

            //to-do get launches timestamp from dbrepository
            //if timestamp+datalifetime <= datetime.now
            //{var launches = _provider.GetLaunches()
            //repo.addRangeLaunches(launches)}
            //

            //repo.GetLaunches
            //return 
        }

        public LaunchViewModel FindLaunchById(int id)
        {
            var launchViewModel = _mapper.Map<LaunchViewModel>(_dbRepository.GetLaunchByIdAsync(id));
            return launchViewModel;
        }

        public async Task<List<LaunchViewModel>> GetUpcomingLaunches()
        {
            var allLaunches = await _dbRepository.GetAllLaunchesAsync();
            
            var upcomingLaunches = new List<LaunchViewModel>();

            foreach (var launchDto in allLaunches)
            {
                if (launchDto.LaunchDate > DateTime.UtcNow)
                {
                    upcomingLaunches.Add(_mapper.Map<LaunchViewModel>(launchDto));
                }
            }

            return upcomingLaunches.OrderBy(launch => launch.LaunchDate).ToList();
        }
    }
}
