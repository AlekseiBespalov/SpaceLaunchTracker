using AutoMapper;
using LaunchAPIConsole.Data.ApiModels.SpaceX.Launches;
using SpaceLaunchTracker.Data.ApiModels.LaunchLibrary.Launches;
using SpaceLaunchTracker.Data.DataModels;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace SpaceLaunchTracker.Mappings
{
    public class DomainProfile : Profile
    {
        public DomainProfile()
        {
            #region SpaceX mappings
            CreateMap<SpaceXLaunchModel, CountryDto>()
                .ForMember(destination => destination.Id,
                    opt => opt.MapFrom(src => new CountryDto
            {
                CountryCode = "USA"
            }));
            
            CreateMap<SpaceXLaunchModel, AgencyDto>()
                .ForMember(destination => destination.Id,
                    opt => opt.MapFrom(src => new AgencyDto
            {
                AgencyName = "SpaceX"
            }));

            CreateMap<SpaceXLaunchModel, LaunchDto>()
                .ForMember(destination => destination.Id, 
                    opt => opt.MapFrom(src => new LaunchDto
            {
                LaunchNumber = src.FlightId,
                MissionName = src.MissionName,
                LaunchDate = src.LaunchDateUtc,
                LaunchSite = src.LaunchSite.SiteName,
                RocketName = src.Rocket.RocketName,
                MissionDetails = src.Details,
                InfoUrl = src.Links.Wikipedia,
                ChangedTime = DateTime.UtcNow,
                UpdatedTime = DateTime.UtcNow
            }));
            #endregion

            #region LaunchLibrary mappings
            CreateMap<LibraryLaunchModel, CountryDto>()
                .ForMember(destination => destination.Id, 
                    opt => opt.MapFrom(src => new CountryDto
            {
                CountryCode = src.Location.CountryCode,
            }));

            CreateMap<LibraryLaunchModel, AgencyDto>().
                ForMember(destination => destination.Id, 
                    opt => opt.MapFrom(src => new AgencyDto
            {
                AgencyName = src.Rocket.Agencies[0].AgencyName
            }));

            CreateMap<LibraryLaunchModel, LaunchDto>()
                .ForMember(destination => destination.Id,
                    opt => opt.MapFrom(src => new LaunchDto
                    {
                        LaunchNumber = src.LaunchId,
                        MissionName = src.LaunchName,
                        LaunchDate = DateTime.ParseExact(src.LaunchTime, "MMMM dd, yyyy, HH:mm:ss UTC", CultureInfo.InvariantCulture),
                        LaunchSite = src.Location.LocationName,
                        RocketName = src.Rocket.RocketName,
                        MissionDetails = src.Missions[0].MissionDescription,
                        InfoUrl = src.Rocket.Agencies[0].WikiUrl,
                        ChangedTime = DateTime.Parse(src.Changed, CultureInfo.InvariantCulture),
                        UpdatedTime = DateTime.UtcNow
                    }));

            #endregion
        }
    }
}
