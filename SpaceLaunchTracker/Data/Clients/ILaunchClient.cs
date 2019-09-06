using System.Collections.Generic;
using System.Threading.Tasks;

namespace SpaceLaunchTracker.Data.Clients
{
    public interface ILaunchClient
    {
        Task<List<ExternalLaunchModel>> GetAllLaunches();
        Task<List<ExternalLaunchModel>> GetUpcomingLaunches();
        Task<ExternalLaunchModel> GetLaunchById(int id);
    }
}
