using InsuranceCP.Model;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InsuranceCP.Data.CategoryRepo
{
    public interface ICateRepo
    {
        Task<IEnumerable<Category>> GetAll();
        Task<Category> GetById(string Id);
        Task Insert(Category company);
        Task<DeleteResult> Delete(string Id);
        Task Update(string Id, Category category);
    }
}
