using InsuranceCP.Data.Level_SubRepo;
using InsuranceCP.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InsuranceCP.Controllers
{
    [Route("LevelSub/[controller]")]
    [ApiController]
    public class Level_SubController : ControllerBase
    {
        public readonly ILvelSubRepo _Level_sub;
        public Level_SubController(ILvelSubRepo level_sub)
        {
            _Level_sub = level_sub;

        }
        [HttpGet]
        public Task<string> Get()
        {
            return this.GetLvelSub();
        }
        [HttpGet]//Fetch
        private async Task<string> GetLvelSub()
        {
            var level_sub = await _Level_sub.GetAll();
            return JsonConvert.SerializeObject(level_sub);
        }
        [HttpPost]//Insert
        public async Task<string> PostLvelSub([FromBody] Level_Sub level_sub)
        {
            await _Level_sub.Insert(level_sub);
            return "Sucessful";
        }
        [HttpDelete("{Id}")]//Delete
        public async Task<string> DeleteLvelSub(string Id)
        {
            if (string.IsNullOrEmpty(Id)) return "Invalid id";
            await _Level_sub.Delete(Id);
            return "Deleted";
        }
        [HttpPut("{Id}")]//Update
        public async Task<string> PutLvelSub(string Id, [FromBody] Level_Sub level_sub)
        {
            if (string.IsNullOrEmpty(Id)) return "Invalid id";

            await _Level_sub.Update(Id, level_sub);
            return "Updated";
        }
    }
}
