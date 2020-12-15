﻿using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace InsuranceCP.Model
{
    public class Company
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Com_Name { get; set; }
        public string Com_Address { get; set; }
        public string Com_Contracts { get; set; }
        public string Com_Pic { get; set; }
        public string Com_Status { get; set; }
    }
}
