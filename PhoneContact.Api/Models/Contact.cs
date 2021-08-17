using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace PhoneContact.Api.Models
{
    public class Contact
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string PhoneNumber { get; set; }
        public string Description { get; set; }

        [BsonRepresentation(BsonType.DateTime)]
        public DateTime CreatedTime { get; set; }

        [BsonRepresentation(BsonType.Boolean)]
        public bool IsActive { get; set; }
    }
}
