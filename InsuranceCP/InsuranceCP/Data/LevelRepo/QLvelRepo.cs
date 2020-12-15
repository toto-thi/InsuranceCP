using InsuranceCP.Model;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InsuranceCP.Data.LevelRepo
{
    public class QLvelRepo : ILvelRepo
    {
        public readonly DbContext _context;
        public QLvelRepo(Settings setting)
        {
            _context = new DbContext(setting);
        }
        public async Task<DeleteResult> Delete(string Id)
        {
            return await _context.Level.DeleteOneAsync(Builders<Level>.Filter.Eq("Id", Id));
        }

        public async Task<IEnumerable<Level>> GetAll()
        {
            return await _context.Level.Find(x => true).ToListAsync();
        }

        public async Task<Level> GetById(string Id)
        {
            var level = Builders<Level>.Filter.Eq("Id", Id);
            return await _context.Level.Find(level).FirstOrDefaultAsync();
        }

        public async Task Insert(Level level)
        {
            await _context.Level.InsertOneAsync(level);
        }

        public async Task Update(string Id, Level level)
        {
            await _context.Level.ReplaceOneAsync(x => x.Id == Id, level);

        }
    }
}
