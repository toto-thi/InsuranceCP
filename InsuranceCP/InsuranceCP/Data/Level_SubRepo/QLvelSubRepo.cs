using InsuranceCP.Model;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InsuranceCP.Data.Level_SubRepo
{
    public class QLvelSubRepo : ILvelSubRepo
    {
        public readonly DbContext _context;
        public QLvelSubRepo(Settings setting)
        {
            _context = new DbContext(setting);
        }
        public async Task<DeleteResult> Delete(string Id)
        {
            return await _context.Level_Sub.DeleteOneAsync(Builders<Level_Sub>.Filter.Eq("Id", Id));
        }

        public async Task<IEnumerable<Level_Sub>> GetAll()
        {
            return await _context.Level_Sub.Find(x => true).ToListAsync();
        }

        public async Task<Level_Sub> GetById(string Id)
        {
            var level_sub = Builders<Level_Sub>.Filter.Eq("Id", Id);
            return await _context.Level_Sub.Find(level_sub).FirstOrDefaultAsync();
        }

        public async Task Insert(Level_Sub level_sub)
        {
            await _context.Level_Sub.InsertOneAsync(level_sub);
        }

        public async Task Update(string Id, Level_Sub level_sub)
        {
            await _context.Level_Sub.ReplaceOneAsync(x => x.Id == Id, level_sub);

        }
    }
}
