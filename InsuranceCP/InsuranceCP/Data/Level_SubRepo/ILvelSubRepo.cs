using InsuranceCP.Model;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InsuranceCP.Data.Level_SubRepo
{
    public interface ILvelSubRepo
    {
        Task<IEnumerable<Level_Sub>> GetAll();
        Task<Level_Sub> GetById(string Id);
        Task Insert(Level_Sub level_sub);
        Task<DeleteResult> Delete(string Id);
        Task Update(string Id, Level_Sub level_sub);
    }
}
