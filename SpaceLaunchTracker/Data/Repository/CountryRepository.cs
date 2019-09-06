using Microsoft.EntityFrameworkCore;
using SpaceLaunchTracker.Data.DataModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SpaceLaunchTracker.Data.Repository
{
    public class CountryRepository : ICountryRepository
    {
        private readonly SpaceLaunchTrackerDbContext _context;

        public CountryRepository(SpaceLaunchTrackerDbContext context)
        {
            _context = context;
        }


        public async Task AddCountriesToDb(IList<CountryDto> countries)
        {
            await _context.AddRangeAsync(countries);
            await SaveChangesAsync();
        }

        public async Task AddCountryToDb(CountryDto country)
        {
            await _context.AddAsync(country);
            await SaveChangesAsync();
        }

        public async Task<int> AddCountryToDbIfNotExists(CountryDto country)
        {
            CountryDto countryDto = await _context.Countries.FirstOrDefaultAsync(c => c.CountryCode == country.CountryCode);

            if (countryDto == null)
            {
                await _context.AddAsync(country);
                await _context.SaveChangesAsync();
                return country.Id;
            }
            else
            {
                return countryDto.Id;
            }
        }

        public async Task<List<CountryDto>> GetAllCountriesAsync()
        {
            return await _context.Countries.ToListAsync();
        }

        public async Task<CountryDto> GetCountryByIdAsync(int countryId)
        {
            return await _context.Countries.FindAsync(countryId);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
