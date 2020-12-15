using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;

namespace InsuranceCP.Model
{
    public class Vehicle
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string name { get; set; }
        public IEnumerable<Turbo_Level> Turbo { get; set; }
        public string status { get; set; }
    }

   
}
