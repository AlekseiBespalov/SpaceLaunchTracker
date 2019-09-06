using SpaceLaunchTracker.Data.DataModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SpaceLaunchTracker.Data.Providers
{
    public interface ILaunchProvider
    {
        Task<LaunchDto> GetLaunchById();

        Task<IList<LaunchDto>> GetAllLaunches();
    }
}
