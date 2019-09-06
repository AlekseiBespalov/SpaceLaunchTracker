using SpaceLaunchTracker.Data.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpaceLaunchTracker.Data.Repository
{
    public interface ICountryRepository
    {
        Task AddCountriesToDb(IList<CountryDto> countries);
        Task<List<CountryDto>> GetAllCountriesAsync();


        Task AddCountryToDb(CountryDto country);
        Task<CountryDto> GetCountryByIdAsync(int countryId);
        Task<int> AddCountryToDbIfNotExists(CountryDto country);


        void SaveChanges();
        Task SaveChangesAsync();
    }
}
