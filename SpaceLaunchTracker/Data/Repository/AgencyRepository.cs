using Microsoft.EntityFrameworkCore;
using SpaceLaunchTracker.Data.DataModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SpaceLaunchTracker.Data.Repository
{
    public class AgencyRepository : IAgencyRepository
    {
        private readonly SpaceLaunchTrackerDbContext _context;

        public AgencyRepository(SpaceLaunchTrackerDbContext context)
        {
            _context = context;
        }


        public async Task AddAgenciesToDb(IList<AgencyDto> agencies)
        {
            await _context.AddRangeAsync(agencies);
            await SaveChangesAsync();
        }

        public async Task AddAgencyToDb(AgencyDto agency)
        {
            await _context.AddAsync(agency);
            await SaveChangesAsync();
        }

        public async Task<int> AddAgencyToDbIfNotExists(AgencyDto agency)
        {
            AgencyDto agencyDto = await _context.Agencies.FirstOrDefaultAsync(a => a.AgencyName == agency.AgencyName);

            if(agencyDto == null)
            {
                await _context.AddAsync(agency);
                await _context.SaveChangesAsync();
                return agency.Id;
            }
            else
            {
                return agencyDto.Id;
            }
        }

        public async Task<AgencyDto> GetAgencyByIdAsync(int agencyId)
        {
            return await _context.Agencies.FindAsync(agencyId);
        }

        public async Task<List<AgencyDto>> GetAllAgenciesAsync()
        {
            return await _context.Agencies.ToListAsync();
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
