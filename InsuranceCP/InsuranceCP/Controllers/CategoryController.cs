using InsuranceCP.Data.CategoryRepo;
using InsuranceCP.Model;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace InsuranceCP.Controllers
{
    [Route("Category/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        public readonly ICateRepo _Category;
        public CategoryController(ICateRepo category)
        {
            _Category = category;

        }
        [HttpGet]
        public Task<string> Get()
        {
            return this.GetCate();
        }
        [HttpGet]//Fetch
        private async Task<string> GetCate()
        {
            var company = await _Category.GetAll();
            return JsonConvert.SerializeObject(company);
        }
        [HttpPost]//Insert
        public async Task<string> PostCate([FromBody] Category category)
        {
            await _Category.Insert(category);
            return "Successful";
        }
        [HttpDelete("{Id}")]//Delete
        public async Task<string> DeleteCate(string Id)
        {
            if (string.IsNullOrEmpty(Id)) return "Invalid id";
            await _Category.Delete(Id);
            return "Deleted";
        }
        [HttpPut("{Id}")]//Update
        public async Task<string> PutCate(string Id, [FromBody] Category category)
        {
            if (string.IsNullOrEmpty(Id)) return "Invalid id";

            await _Category.Update(Id, category);
            return "Updated";
        }
    }
}
