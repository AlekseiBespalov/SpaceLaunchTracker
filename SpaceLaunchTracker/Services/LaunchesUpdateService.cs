using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using SpaceLaunchTracker.Data;
using SpaceLaunchTracker.Data.Clients;
using SpaceLaunchTracker.Data.DataModels;
using SpaceLaunchTracker.Data.Repository;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace SpaceLaunchTracker.Services
{
    internal class LaunchesUpdateService : IHostedService, IDisposable
    {
        //private readonly ILogger _logger;
        //private Timer _timer;

        //private readonly ILaunchRepository _launchRepository;
        //private readonly IAgencyRepository _agencyRepository;
        //private readonly ICountryRepository _countryRepository;

        //private readonly ILaunchClient _spaceXClient;
        //private readonly ILaunchClient _launchLibraryClient;

        //public LaunchesUpdateService(ILogger<LaunchesUpdateService> logger, ILaunchClient spaceXClient, ILaunchClient launchLibraryClient,
        //    ILaunchRepository launchRepository, IAgencyRepository agencyRepository, ICountryRepository countryRepository)
        //{
        //    _logger = logger;

        //    _launchRepository = launchRepository;
        //    _agencyRepository = agencyRepository;
        //    _countryRepository = countryRepository;

        //    _spaceXClient = spaceXClient;
        //    _launchLibraryClient = launchLibraryClient;
        //}

        private readonly IServiceProvider _serviceProvider;
        private readonly ILogger _logger;
        private Timer _timer;

        public LaunchesUpdateService(IServiceProvider provider, ILogger<LaunchesUpdateService> logger)
        {
            _serviceProvider = provider;
            _logger = logger;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Background update service is starting.");
            _timer = new Timer(UpdateDbRecordsFromApi, null, TimeSpan.Zero, TimeSpan.FromSeconds(30));

            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Background update service is stopping.");
            _timer?.Change(Timeout.Infinite, 0);

            return Task.CompletedTask;
        }

        private async void UpdateDbRecordsFromApi(object state)
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var spaceXClient = scope.ServiceProvider.GetRequiredService<ILaunchClient>();
                var launchRepository = scope.ServiceProvider.GetRequiredService<ILaunchRepository>();
                var agencyRepository = scope.ServiceProvider.GetRequiredService<IAgencyRepository>();
                var countryRepository = scope.ServiceProvider.GetRequiredService<ICountryRepository>();

                var spaceXLaunches = await spaceXClient.GetAllLaunches();

                await launchRepository.AddLaunchesToDbIfNotExist(ConvertExternalLaunchToDto(spaceXLaunches));

                foreach (ExternalLaunchModel spaceXLaunch in spaceXLaunches)
                {
                    await agencyRepository.AddAgencyToDbIfNotExists(
                        new AgencyDto
                        {
                            AgencyName = "SpaceX",
                            InfoUrl = "https://wikipedia.org/wiki/SpaceX"
                        });
                }

                foreach (ExternalLaunchModel spaceXLaunch in spaceXLaunches)
                {
                    await countryRepository.AddCountryToDbIfNotExists(
                        new CountryDto
                        {
                            CountryCode = spaceXLaunch.CountryCode
                        });
                }

                //var launchLibraryLaunches = _launchLibraryClient.GetAllLaunches();

                //launchRepository.AddLaunchesToDbIfNotExist(ConvertExternalLaunchToDto(launchLibraryLaunches));

                //foreach (ExternalLaunchModel libraryLaunch in launchLibraryLaunches)
                //{
                //    agencyRepository.AddAgencyToDbIfNotExists(
                //        new AgencyDto
                //        {
                //            AgencyName = libraryLaunch.AgencyName
                //        });
                //}
            }
        }

        private List<LaunchDto> ConvertExternalLaunchToDto(List<ExternalLaunchModel> extLaunchesModel)
        {
            List<LaunchDto> launches = new List<LaunchDto>();
    
            foreach (ExternalLaunchModel launch in extLaunchesModel)
            {
                launches.Add(new LaunchDto
                {
                    LaunchNumber = launch.LaunchId,
                    MissionName = launch.MissionName,
                    LaunchDate = launch.LaunchDate,
                    LaunchSite = launch.LaunchSite,
                    RocketName = launch.RocketName,
                    MissionDetails = launch.MissionDetails,
                    InfoUrl = launch.InfoUrl,
                    ChangedTime = launch.ChangedTime,
                    UpdatedTime = DateTime.UtcNow,
                });
            }

            return launches;
        }

        public void Dispose()
        {
            _timer?.Dispose();
        }
    }
}
