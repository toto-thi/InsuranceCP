using InsuranceCP.Model;
using Microsoft.AspNetCore.Hosting;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using System.Collections.Generic;
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

        public async Task<IEnumerable<Company>> GetAll(string http, string host, string port)
        {
            var projection = Builders<Company>.Projection.Expression(c => new Company
            {
                Id = c.Id,
                Com_Name = c.Com_Name,
                Com_Address = c.Com_Address,
                Com_Contracts = c.Com_Contracts,
                Com_Pic_Name = c.Com_Pic_Name,
                Com_Pic_Path=string.Format("{0}://{1}{2}/Image/{3}",http,host,port,c.Com_Pic_Name),
                Com_Status = c.Com_Status
            });

            return await _context.Company.Find(x => true).Project(projection).ToListAsync();
            
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
