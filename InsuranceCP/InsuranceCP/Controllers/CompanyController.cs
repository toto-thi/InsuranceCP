using AutoMapper;
using InsuranceCP.Data.CompanyRepo;
using InsuranceCP.Dto;
using InsuranceCP.Model;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace InsuranceCP.Controllers
{
    [Route("Company/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        public readonly IComRepo _Company;
        public IWebHostEnvironment _environment;
        public IMapper _mapper;
        public CompanyController(IComRepo company, IWebHostEnvironment environment, IMapper mapper)
        {
            _Company = company;
            _environment = environment;
            _mapper = mapper;


        }
        [HttpGet]
        public Task<string> Get()
        {
            return this.GetCom();
        }
        [HttpGet]//Fetch
        private async Task<string> GetCom()
        {
            string http = Request.Scheme;
            string host = string.Format("{0}",Request.Host);
            string port = Request.PathBase;
          
            var company = await _Company.GetAll(http, host, port);

            //return _mapper.Map<IEnumerable<CompanyReadDto>>(company);
            return JsonConvert.SerializeObject(company);
        }
        [HttpPost]//Insert
        public async Task<string> PostCom([FromForm]Company company)
        {
            company.Com_Pic_Name = await SaveImage(company.Com_Pic);
            await _Company.Insert(company);
            
            return "ok";

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
        [NonAction]
        public async Task<string> SaveImage(IFormFile imagefile)
        {
            /*if (imagefile.Length > 0)
             {
                     if (!Directory.Exists(_environment.WebRootPath + "\\uploads\\"))
                     {
                         Directory.CreateDirectory(_environment.WebRootPath + "\\uploads\\");
                     }
                     using (FileStream filestream = System.IO.File.Create(_environment.WebRootPath + "\\uploads\\" + imagefile.FileName))
                     {
                         await imagefile.CopyToAsync(filestream);
                         

                          return  imagefile.FileName;
                     }
               

            }
             else
             {
                 return "Unsuccessful";
             }*/
            string imageName = new string(Path.GetFileNameWithoutExtension(imagefile.FileName).Take(10).ToArray()).Replace(' ','-');
            imageName = imageName + DateTime.Now.ToString("yymmssff") + Path.GetExtension(imagefile.FileName);
            var imagePath = Path.Combine(_environment.ContentRootPath, "Image", imageName);
            using (var fileStream = new FileStream(imagePath, FileMode.Create))
            {
                await imagefile.CopyToAsync(fileStream);
            }
            return imageName;
        }
    }
}
