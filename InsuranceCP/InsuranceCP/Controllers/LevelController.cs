using InsuranceCP.Data.LevelRepo;
using InsuranceCP.Model;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace InsuranceCP.Controllers
{
    [Route("Level/[controller]")]
    [ApiController]
    public class LevelController : ControllerBase
    {
        public readonly ILvelRepo _Level;
        public LevelController(ILvelRepo level)
        {
            _Level = level;

        }
        [HttpGet]
        public Task<string> Get()
        {
            return this.GetLvel();
        }
        [HttpGet]//Fetch
        private async Task<string> GetLvel()
        {
            var level = await _Level.GetAll();
            return JsonConvert.SerializeObject(level);
        }
        [HttpPost]//Insert
        public async Task<string> PostLvel([FromBody] Level level)
        {
            await _Level.Insert(level);
            return "Successful";
        }
        [HttpDelete("{Id}")]//Delete
        public async Task<string> DeleteLvel(string Id)
        {
            if (string.IsNullOrEmpty(Id)) return "Invalid id";
            await _Level.Delete(Id);
            return "Deleted";
        }
        [HttpPut("{Id}")]//Update
        public async Task<string> PutLvel(string Id, [FromBody] Level level)
        {
            if (string.IsNullOrEmpty(Id)) return "Invalid id";

            await _Level.Update(Id, level);
            return "Updated";
        }
    }
}
