using InsuranceCP.Model;
using Microsoft.AspNetCore.Hosting;
using MongoDB.Driver;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace InsuranceCP.Data.CompanyRepo
{
    public class QComRepo : IComRepo
    {
        public readonly DbContext _context;
        public static IWebHostEnvironment _enviroment;
        public QComRepo(Settings setting, IWebHostEnvironment environment)
        {
            _context = new DbContext(setting);
            _enviroment = environment;
        }
        public async Task<DeleteResult> Delete(string Id)
        {
           return await _context.Company.DeleteOneAsync(Builders<Company>.Filter.Eq("Id", Id));
        }

        public async Task<IEnumerable<Company>> GetAll()
        {
            return await _context.Company.Find(x => true).ToListAsync();
        }

        public async Task<Company> GetById(string Id)
        {
            var company = Builders<Company>.Filter.Eq("Id", Id);
            return await _context.Company.Find(company).FirstOrDefaultAsync();
        }

        public async Task Insert(Company company)
        {
           
            await _context.Company.InsertOneAsync(company);
        }

        public async Task Update(string Id, Company company)
        {
            await _context.Company.ReplaceOneAsync(x=>x.Id == Id, company);
            
        }
        

    }
}
