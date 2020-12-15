using InsuranceCP.Model;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InsuranceCP.Data.Turbo_LevelRepo
{
    public class QTurboRepo:ITurboRepo
    {
        public readonly DbContext _context;
        public QTurboRepo(Settings setting)
        {
            _context = new DbContext(setting);
        }
        public async Task<DeleteResult> Delete(string Id)
        {
            return await _context.Turbo_Level.DeleteOneAsync(Builders<Turbo_Level>.Filter.Eq("Id", Id));
        }

        public async Task<IEnumerable<Turbo_Level>> GetAll()
        {
            return await _context.Turbo_Level.Find(x => true).ToListAsync();
        }

        public async Task<Turbo_Level> GetById(string Id)
        {
            var turbo = Builders<Turbo_Level>.Filter.Eq("Id", Id);
            return await _context.Turbo_Level.Find(turbo).FirstOrDefaultAsync();
        }

        public async Task Insert(Turbo_Level turbo)
        {
            await _context.Turbo_Level.InsertOneAsync(turbo);
        }

        public async Task Update(string Id, Turbo_Level turbo)
        {
            await _context.Turbo_Level.ReplaceOneAsync(x => x.Id == Id, turbo);

        }
    }
}
