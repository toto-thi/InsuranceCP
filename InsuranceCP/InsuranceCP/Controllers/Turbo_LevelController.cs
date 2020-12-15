using System.Threading.Tasks;
using InsuranceCP.Data.Turbo_LevelRepo;
using InsuranceCP.Model;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace InsuranceCP.Controllers
{
    [Route("Turbo/[controller]")]
    [ApiController]
    public class Turbo_LevelController : ControllerBase
    {
        public readonly ITurboRepo _Turbo;
        public Turbo_LevelController(ITurboRepo turbo)
        {
            _Turbo = turbo;

        }
        [HttpGet]
        public Task<string> Get()
        {
            return this.GetTurbo();
        }
        [HttpGet]//Fetch
        private async Task<string> GetTurbo()
        {
            var turbo = await _Turbo.GetAll();
            return JsonConvert.SerializeObject(turbo);
        }
        [HttpPost]//Insert
        public async Task<string> PostTurbo([FromBody] Turbo_Level turbo)
        {
            await _Turbo.Insert(turbo);
            return "Succesful";
        }
        [HttpDelete("{Id}")]//Delete
        public async Task<string> DeletTurbo(string Id)
        {
            if (string.IsNullOrEmpty(Id)) return "Invalid id";
            await _Turbo.Delete(Id);
            return "Deleted";
        }
        [HttpPut("{Id}")]//Update
        public async Task<string> PutTurbo(string Id, [FromBody] Turbo_Level turbo)
        {
            if (string.IsNullOrEmpty(Id)) return "Invalid id";

            await _Turbo.Update(Id, turbo);
            return "Updated";
        }
    }
}
