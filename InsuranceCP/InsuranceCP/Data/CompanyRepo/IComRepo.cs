using InsuranceCP.Model;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InsuranceCP.Data.CompanyRepo
{
    public interface IComRepo
    {
        Task<IEnumerable<Company>> GetAll();
        Task<Company> GetById(string Id);
        Task Insert(Company company);
        Task<DeleteResult> Delete(string Id);
        Task Update(string Id, Company company);
    }
}
