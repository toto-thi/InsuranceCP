using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;


namespace InsuranceCP.Model
{
    public class Turbo_Level
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Turbo{ get; set; }
    }
}
