using InsuranceCP.Model;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InsuranceCP.Data.VehicleRepo
{
    public class QVehicleRepo:IVehicleRepo
    {
        public readonly DbContext _context;
        public QVehicleRepo(Settings setting)
        {
            _context = new DbContext(setting);
        }
        public async Task<DeleteResult> Delete(string Id)
        {
            return await _context.Vehicle.DeleteOneAsync(Builders<Vehicle>.Filter.Eq("Id", Id));
        }

        public async Task<IEnumerable<Vehicle>> GetAll()
        {
            return await _context.Vehicle.Find(x => true).ToListAsync();
        }

        public async Task<Vehicle> GetById(string Id)
        {
            var vehicle = Builders<Vehicle>.Filter.Eq("Id", Id);
            return await _context.Vehicle.Find(vehicle).FirstOrDefaultAsync();
        }

        public async Task Insert(Vehicle vehicle)
        {
            await _context.Vehicle.InsertOneAsync(vehicle);
        }

        public async Task Update(string Id, Vehicle vehicle)
        {
            await _context.Vehicle.ReplaceOneAsync(x => x.Id == Id, vehicle);

        }
    }
}
