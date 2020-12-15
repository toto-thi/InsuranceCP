using InsuranceCP.Model;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InsuranceCP.Data.Turbo_LevelRepo
{
    public interface ITurboRepo
    {
        Task<IEnumerable<Turbo_Level>> GetAll();
        Task<Turbo_Level> GetById(string Id);
        Task Insert(Turbo_Level turbo);
        Task<DeleteResult> Delete(string Id);
        Task Update(string Id, Turbo_Level turbo);
    }
}
