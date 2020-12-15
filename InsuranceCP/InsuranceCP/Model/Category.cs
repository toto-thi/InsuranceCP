using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;


namespace InsuranceCP.Model
{
    public class Category
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Cate_Name { get; set; }
    }
}
