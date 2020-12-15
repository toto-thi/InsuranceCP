using InsuranceCP.Model;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InsuranceCP.Data.CategoryRepo
{
    public class QCateRepo : ICateRepo
    {
        public readonly DbContext _context;
        public QCateRepo(Settings setting)
        {
            _context = new DbContext(setting);
        }
        public async Task<DeleteResult> Delete(string Id)
        {
            return await _context.Category.DeleteOneAsync(Builders<Category>.Filter.Eq("Id", Id));
        }

        public async Task<IEnumerable<Category>> GetAll()
        {
            return await _context.Category.Find(x => true).ToListAsync();
        }

        public async Task<Category> GetById(string Id)
        {
            var category = Builders<Category>.Filter.Eq("Id", Id);
            return await _context.Category.Find(category).FirstOrDefaultAsync();
        }

        public async Task Insert(Category category)
        {
            await _context.Category.InsertOneAsync(category);
        }

        public async Task Update(string Id, Category category)
        {
            await _context.Category.ReplaceOneAsync(x => x.Id == Id, category);
        }
    }
}
