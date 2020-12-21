using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InsuranceCP.Dto
{
    public class CompanyReadDto
    {
        public string Id { get; set; }
        public string Com_Name { get; set; }
        public string Com_Address { get; set; }
        public string Com_Contracts { get; set; }
        public string Com_Pic_Name { get; set; }
        public string Com_Pic_Path { get; set; }
        public string Com_Status { get; set; }
    }
}
