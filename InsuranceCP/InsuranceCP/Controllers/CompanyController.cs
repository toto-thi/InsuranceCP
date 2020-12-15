using AutoMapper;
using InsuranceCP.Data.CompanyRepo;
using InsuranceCP.Model;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace InsuranceCP.Controllers
{
    [Route("Company/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        public readonly IComRepo _Company;
        public static IWebHostEnvironment _enviroment;
        public CompanyController(IComRepo company, IWebHostEnvironment environment)
        {
            _Company = company;
            _enviroment = environment;
           
        }
        [HttpGet]
        public Task<string> Get()
        {
            return this.GetCom();
        }
        [HttpGet]//Fetch
        private async Task<string> GetCom()
        {
            var company = await _Company.GetAll();
            return JsonConvert.SerializeObject(company);
        }
        [HttpPost]//Insert
        public async Task<string> PostCom([FromBody]Company company)
        {
            /*List<Company> comlist = JsonConvert.DeserializeObject<List<Company>>(ComImage.Company);*/
            /*if (ifile.Length > 0)
            {
                if (!Directory.Exists(_enviroment.WebRootPath + "\\Image\\"))
                {
                    Directory.CreateDirectory(_enviroment.WebRootPath + "\\Image\\");
                }
                using (FileStream filestream = System.IO.File.Create(_enviroment.WebRootPath + "\\Image\\" + ifile.FileName))
                {
                    await ifile.CopyToAsync(filestream);
                    company.Com_pic = ifile.FileName;
                    await _Company.Insert(company);
                    filestream.Flush();
                    return "Uploaded";

                }
            }*/

            await _Company.Insert(company);
            return "Succesful";
        }
        [HttpDelete("{Id}")]//Delete
        public async Task<string> DeleteCom(string Id)
        {
            if (string.IsNullOrEmpty(Id)) return "Invalid id";
            await _Company.Delete(Id);
            return "Deleted";
        }
        [HttpPut("{Id}")]//Update
        public async Task<string> PutCom(string Id, [FromBody] Company company)
        {
            if (string.IsNullOrEmpty(Id)) return "Invalid id";
    
            await _Company.Update(Id, company);
            return "Updated";
        }
      
    }
}
