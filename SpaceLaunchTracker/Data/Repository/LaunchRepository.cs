using Microsoft.EntityFrameworkCore;
using SpaceLaunchTracker.Data.DataModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SpaceLaunchTracker.Data.Repository
{
    public class LaunchRepository : ILaunchRepository
    {
        private readonly SpaceLaunchTrackerDbContext _context;

        public LaunchRepository(SpaceLaunchTrackerDbContext context)
        {
            _context = context;
        }

        public async Task AddLaunchesToDbIfNotExist(IList<LaunchDto> launches)
        {
            List<LaunchDto> launchesToDb = new List<LaunchDto>();

            foreach(LaunchDto launch in launches)
            {
                LaunchDto existLaunch = await _context.Launches.FirstOrDefaultAsync(l => l.Id == launch.Id);
                if(existLaunch == null)
                {
                    await _context.AddAsync(launch);
                }
            }
        }

        public Task AddLaunchToDbIfNotExist(LaunchDto launch)
        {
            throw new System.NotImplementedException();
        }

        public async Task AddLaunchesToDb(IList<LaunchDto> launches)
        {
            await _context.AddRangeAsync(launches);
            await SaveChangesAsync();
        }

        public async Task<List<LaunchDto>> GetAllLaunchesAsync()
        {
            return await _context.Launches.ToListAsync();
        }

        public async Task AddLaunchToDb(LaunchDto launch)
        {
            await _context.AddAsync(launch);
            await SaveChangesAsync();
        }

        public async Task<LaunchDto> GetLaunchByIdAsync(int launchId)
        {
            return await _context.Launches.FindAsync(launchId);
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