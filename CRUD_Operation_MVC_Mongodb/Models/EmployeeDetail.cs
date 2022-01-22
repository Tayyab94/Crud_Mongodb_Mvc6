using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace CRUD_Operation_MVC_Mongodb.Models
{
    public class EmployeeDetail
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public String Id { get; set; }
        public string Name { get; set; }
        public string Department { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
    }
}
