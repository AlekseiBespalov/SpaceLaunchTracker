using SpaceLaunchTracker.Data.DataModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SpaceLaunchTracker.Data.Repository
{
    public interface ILaunchRepository
    {
        Task AddLaunchesToDb(IList<LaunchDto> launches);
        Task AddLaunchesToDbIfNotExist(IList<LaunchDto> launches);
        Task<List<LaunchDto>> GetAllLaunchesAsync();


        Task AddLaunchToDb(LaunchDto launch);
        Task<int> AddLaunchToDbIfNotExist(LaunchDto launch);
        Task<LaunchDto> GetLaunchByIdAsync(int launchId);


        void SaveChanges();
        Task SaveChangesAsync();
    }
}
