using AutoMapper;
using LaunchAPIConsole.Data.ApiModels.SpaceX.Launches;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using SpaceLaunchTracker.Configuration;
using SpaceLaunchTracker.Data.Clients;
using SpaceLaunchTracker.Data.DataModels;
using SpaceLaunchTracker.Data.Repository;
using System;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using SpaceLaunchTracker.Data.ApiModels.LaunchLibrary.Launches;

namespace SpaceLaunchTracker.Services
{
    internal class LaunchesUpdateService : IHostedService, IDisposable
    {
        private readonly DataUpdatesConfiguration _dataUpdatesConfiguration;
        private readonly IServiceProvider _serviceProvider;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;
        private Timer _timer;

        public LaunchesUpdateService(IServiceProvider provider, IMapper mapper,
            ILogger<LaunchesUpdateService> logger, IOptionsMonitor<DataUpdatesConfiguration> dataUpdatesConfiguration)
        {
            _dataUpdatesConfiguration = dataUpdatesConfiguration.CurrentValue;
            _serviceProvider = provider;
            _mapper = mapper;
            _logger = logger;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Background update service is starting.");
            _timer = new Timer(UpdateDbRecordsFromApi, null, TimeSpan.Zero, TimeSpan.FromSeconds(_dataUpdatesConfiguration.DataLifetimeMinutes));

            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Background update service is stopping.");
            _timer?.Change(Timeout.Infinite, 0);

            return Task.CompletedTask;
        }

        bool _firstUpdate = false;
        private async void UpdateDbRecordsFromApi(object state)
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var spaceXClient = scope.ServiceProvider.GetRequiredService<ILaunchClient<SpaceXLaunchModel>>();
                var launchLibraryClient = scope.ServiceProvider.GetRequiredService<ILaunchClient<LibraryLaunchModel>>();
                var launchRepository = scope.ServiceProvider.GetRequiredService<ILaunchRepository>();
                var agencyRepository = scope.ServiceProvider.GetRequiredService<IAgencyRepository>();
                var countryRepository = scope.ServiceProvider.GetRequiredService<ICountryRepository>();


                if (_firstUpdate == true)
                {
                    var spaceXLaunches = await spaceXClient.GetAllLaunches();

                    foreach (var spaceXLaunch in spaceXLaunches)
                    {
                        var country = ConvertSpaceXCountryModelToDto(); //map to dto

                        // add to repository (get id)
                        var countryId = await countryRepository.AddCountryToDbIfNotExists(country);

                        var agency = ConvertSpaceXAgencyModelToDto(countryId);
                        var agencyId = await agencyRepository.AddAgencyToDbIfNotExists(agency);

                        var launch = ConvertSpaceXLaunchToDto(spaceXLaunch, countryId, agencyId);
                        await launchRepository.AddLaunchToDbIfNotExist(launch);
                    }
                    _firstUpdate = false;
                }
                else
                {
                    var spaceXLaunches = await spaceXClient.GetUpcomingLaunches();

                    foreach (var spaceXLaunch in spaceXLaunches)
                    {
                        var country = ConvertSpaceXCountryModelToDto();

                        var countryId = await countryRepository.AddCountryToDbIfNotExists(country);

                        var agency = ConvertSpaceXAgencyModelToDto(countryId);
                        var agencyId = await agencyRepository.AddAgencyToDbIfNotExists(agency);

                        var launch = ConvertSpaceXLaunchToDto(spaceXLaunch, countryId, agencyId);
                        await launchRepository.AddLaunchToDbIfNotExist(launch);
                    }
                }

                var launchLibraryLaunches = await launchLibraryClient.GetUpcomingLaunches();

                foreach (var launchLibraryLaunch in launchLibraryLaunches)
                {
                    var country = ConvertLaunchLibraryCountryModelToDto(launchLibraryLaunch);
                    var countryId = await countryRepository.AddCountryToDbIfNotExists(country);

                    var agency = ConvertLaunchLibraryAgencyModelToDto(launchLibraryLaunch, countryId);
                    var agencyId = await agencyRepository.AddAgencyToDbIfNotExists(agency);

                    var launch = ConvertLaunchLibraryLaunchModelToDto(launchLibraryLaunch, countryId, agencyId);
                    await launchRepository.AddLaunchToDbIfNotExist(launch);
                }
            }
        }

        public void Dispose()
        {
            _timer?.Dispose();
        }

        #region SpaceX mappings
        // LaunchDto (ExternalLaunchModel)
        private LaunchDto ConvertSpaceXLaunchToDto(SpaceXLaunchModel launch, int countryId, int agencyId)
        {
            var launchDto = new LaunchDto
            {
                LaunchNumber = launch.FlightId,
                MissionName = launch.MissionName,
                LaunchDate = launch.LaunchDateUtc,
                LaunchSite = launch.LaunchSite.SiteNameLong,
                RocketName = launch.Rocket.RocketName,
                MissionDetails = launch.Details,
                InfoUrl = launch.Links.Wikipedia,
                ChangedTime = DateTime.UtcNow,
                UpdatedTime = DateTime.UtcNow,
                Country = new CountryDto { Id = countryId },
                Agency = new AgencyDto { Id = agencyId }
            };
            return launchDto;
        }

        private CountryDto ConvertSpaceXCountryModelToDto()
        {
            var countryDto = new CountryDto
            {
                CountryCode = "USA"
            };
            return countryDto;
        }

        private AgencyDto ConvertSpaceXAgencyModelToDto(int countryId)
        {
            var agencyDto = new AgencyDto
            {
                AgencyName = "SpaceX",
                InfoUrl = "https://wikipedia.org/wiki/SpaceX",
                Country = new CountryDto { Id = countryId}
            };
            return agencyDto;
        }
        #endregion

        #region LaunchLibrary mappings

        private CountryDto ConvertLaunchLibraryCountryModelToDto(LibraryLaunchModel launch)
        {
            var countryDto = new CountryDto
            {
                CountryCode = launch.Location.CountryCode
            };
            return countryDto;
        }

        private AgencyDto ConvertLaunchLibraryAgencyModelToDto(LibraryLaunchModel launch, int countryId)
        {
            var agencyDto = new AgencyDto
            {
                AgencyName = launch.Location?.Pads?.FirstOrDefault()?.Agencies?.FirstOrDefault()?.AgencyName,
                InfoUrl = launch.Location.Pads.FirstOrDefault().WikiURL,
                Country =  new CountryDto { Id = countryId }
            };
            return agencyDto;
        }

        private LaunchDto ConvertLaunchLibraryLaunchModelToDto(LibraryLaunchModel launch, int countryId, int agencyId)
        {
            var launchDto = new LaunchDto
            {
                LaunchNumber = launch.LaunchId,
                MissionName = launch.LaunchName,
                LaunchDate = DateTime.ParseExact(launch.LaunchTime, "MMMM dd, yyyy HH:mm:ss UTC", CultureInfo.InvariantCulture),
                LaunchSite = launch.Location.LocationName,
                RocketName = launch.Rocket.RocketName,
                MissionDetails = launch.Missions?.FirstOrDefault()?.MissionDescription,
                InfoUrl = launch.Location?.Pads?.FirstOrDefault()?.InfoUrl,
                ChangedTime = DateTime.Parse(launch.Changed, CultureInfo.InvariantCulture),
                UpdatedTime = DateTime.UtcNow,
                Country = new CountryDto { Id = countryId },
                Agency = new AgencyDto { Id = agencyId }
            };
            return launchDto;
        }

        #endregion
    }
}
