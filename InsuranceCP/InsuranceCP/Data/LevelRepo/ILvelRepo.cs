using InsuranceCP.Model;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InsuranceCP.Data.LevelRepo
{
    public interface ILvelRepo
    {
        Task<IEnumerable<Level>> GetAll();
        Task<Level> GetById(string Id);
        Task Insert(Level level);
        Task<DeleteResult> Delete(string Id);
        Task Update(string Id, Level level);
    }
}
