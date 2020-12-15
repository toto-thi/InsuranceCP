using InsuranceCP.Model;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InsuranceCP.Data.VehicleRepo
{
    public interface IVehicleRepo
    {
        Task<IEnumerable<Vehicle>> GetAll();
        Task<Vehicle> GetById(string Id);
        Task Insert(Vehicle vehicle);
        Task<DeleteResult> Delete(string Id);
        Task Update(string Id, Vehicle vehicle);
    }
}
