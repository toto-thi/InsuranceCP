using InsuranceCP.Model;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;

namespace InsuranceCP.Data
{
    public class DbContext
    {
       
        public IMongoDatabase _db;
        
        //Connection 
        public DbContext(Settings setting)
        {

           var con = new MongoClient(setting.ConnectionString);
            
            if (con != null)
            {
                _db = con.GetDatabase(setting.Database);
            }
        }
        //Collection catagory
        public IMongoCollection<Category> Category
        {
            get
            {
                return _db.GetCollection<Category>("Category");
            }
        }
        //Collection company
        public IMongoCollection<Company> Company
        {
            get
            {
                return _db.GetCollection<Company>("Company");
            }
        }
        //Collection Level
        public IMongoCollection<Level> Level
        {
            get
            {
                return _db.GetCollection<Level>("Level");
            }
        }
        //Collection level_sub
        public IMongoCollection<Level_Sub> Level_Sub
        {
            get
            {
                return _db.GetCollection<Level_Sub>("Level Sub");
            }
        }
        //Collection turbo_level
        public IMongoCollection<Turbo_Level> Turbo_Level
        {
            get
            {
                return _db.GetCollection<Turbo_Level>("Turbo Level");
            }
        }
        //Collection vehicle
        public IMongoCollection<Vehicle> Vehicle
        {
            get
            {
                return _db.GetCollection<Vehicle>("Vehicle");
            }
        }
    }
}
