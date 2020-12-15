using InsuranceCP.Data.VehicleRepo;
using InsuranceCP.Model;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace InsuranceCP.Controllers
{
    [Route("Vehicle/[controller]")]
    public class VehicleController : ControllerBase
    {
        public readonly IVehicleRepo _Vehicle;
        public VehicleController(IVehicleRepo vehicle)
        {
            _Vehicle = vehicle;

        }
        [HttpGet]
        public Task<string> Get()
        {
            return this.GetVehicle();
        }
        [HttpGet]//Fetch
        private async Task<string> GetVehicle()
        {
            var vehicle = await _Vehicle.GetAll();
            return JsonConvert.SerializeObject(vehicle);
        }
        [HttpPost]//Insert
        public async Task<string> PostVehicle([FromBody] Vehicle vehicle)
        {
            await _Vehicle.Insert(vehicle);
            return "Succesful";
        }
        [HttpDelete("{Id}")]//Delete
        public async Task<string> DeletVehicle(string Id)
        {
            if (string.IsNullOrEmpty(Id)) return "Invalid id";
            await _Vehicle.Delete(Id);
            return "Deleted";
        }
        [HttpPut("{Id}")]//Update
        public async Task<string> PutVehicle(string Id, [FromBody] Vehicle vehicle)
        {
            if (string.IsNullOrEmpty(Id)) return "Invalid id";

            await _Vehicle.Update(Id, vehicle);
            return "Updated";
        }
    }
}
