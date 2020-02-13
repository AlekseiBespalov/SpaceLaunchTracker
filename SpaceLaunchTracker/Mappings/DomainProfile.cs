using AutoMapper;
using LaunchAPIConsole.Data.ApiModels.SpaceX.Launches;
using SpaceLaunchTracker.Data.ApiModels.LaunchLibrary.Launches;
using SpaceLaunchTracker.Data.DataModels;
using SpaceLaunchTracker.Models;
using System;
using System.Globalization;

namespace SpaceLaunchTracker.Mappings
{
    public class DomainProfile : Profile
    {
        public DomainProfile()
        {
            #region SpaceX mappings

            CreateMap<SpaceXLaunchModel, CountryDto>()
                .BeforeMap((s, d) => d.CountryCode = "USA");

            CreateMap<SpaceXLaunchModel, AgencyDto>()
                .BeforeMap((s, d) => d.AgencyName = "SpaceX")
                .BeforeMap((s, d) => d.InfoUrl = "https://wikipedia.org/wiki/SpaceX")
                .BeforeMap((s, d) => d.Country = new CountryDto {Id = 1});

            CreateMap<SpaceXLaunchModel, LaunchDto>()
                .BeforeMap((s, d) => d.Id = s.FlightId)
                .BeforeMap((s, d) => d.MissionName = s.MissionName)
                .BeforeMap((s, d) => d.LaunchDate = s.LaunchDateUtc)
                .BeforeMap((s, d) => d.LaunchSite = s.LaunchSite.SiteNameLong)
                .BeforeMap((s, d) => d.RocketName = s.Rocket.RocketName)
                .BeforeMap((s, d) => d.MissionDetails = s.Details)
                .BeforeMap((s, d) => d.InfoUrl = s.Links.Wikipedia)
                .BeforeMap((s, d) => d.ChangedTime = DateTime.UtcNow)
                .BeforeMap((s, d) => d.UpdatedTime = DateTime.UtcNow)
                .BeforeMap((s, d) => d.Country = new CountryDto {Id = 1})
                .BeforeMap((s, d) => d.Agency = new AgencyDto {Id = 1});

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

            #region DtoToViewMappings

            CreateMap<CountryDto, CountryViewModel>()
                .ForMember(dest => dest.CountryId, opt => opt.MapFrom(dto => dto.Id));

            CreateMap<AgencyDto, AgencyViewModel>()
                .ForMember(dest => dest.AgencyId, opt => opt.MapFrom(dto => dto.Id));

            CreateMap<LaunchDto, LaunchViewModel>()
                .ForMember(dest => dest.LaunchId, opt => opt.MapFrom(dto => dto.Id));

            #endregion
        }
    }
}
