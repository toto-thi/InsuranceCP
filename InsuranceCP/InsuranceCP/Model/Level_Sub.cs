using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;


namespace InsuranceCP.Model
{
    public class Level_Sub
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        
        public IEnumerable<Company> Com_name { get; set; } 
        public IEnumerable<Category> Cate_name { get; set; }
        public IEnumerable<Vehicle> Vehicles { get; set; }
        public IEnumerable<Level> Lvl_Name { get; set; }
        public string TPL_cover { get; set; }
        public string Own_cover { get; set; }
        public string Price { get; set; }
        
    }
}
