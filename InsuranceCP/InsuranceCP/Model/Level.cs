using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace InsuranceCP.Model
{
    public class Level
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Lvl_Name { get; set; }
    }
}
