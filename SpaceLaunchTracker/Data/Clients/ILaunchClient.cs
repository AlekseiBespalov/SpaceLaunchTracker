using System.Collections.Generic;
using System.Threading.Tasks;

namespace SpaceLaunchTracker.Data.Clients
{
    public interface ILaunchClient<T> where T : class
    {
        Task<List<T>> GetAllLaunches();
        Task<List<T>> GetUpcomingLaunches();
        Task<T> GetLaunchById(int id);
    }
}
