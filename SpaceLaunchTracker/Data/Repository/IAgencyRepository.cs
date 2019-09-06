using SpaceLaunchTracker.Data.DataModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SpaceLaunchTracker.Data.Repository
{
    public interface IAgencyRepository
    {
        Task AddAgenciesToDb(IList<AgencyDto> agencies);
        Task<List<AgencyDto>> GetAllAgenciesAsync();


        Task AddAgencyToDb(AgencyDto agency);
        Task<AgencyDto> GetAgencyByIdAsync(int agencyId);
        Task<int> AddAgencyToDbIfNotExists(AgencyDto agency);


        void SaveChanges();
        Task SaveChangesAsync();
    }
}
