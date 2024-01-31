using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace Mongodb.Models
{
    public class Status
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("StatusID")]
        public int StatusID { get; set; }

        [BsonElement("StatusName")]
        public string StatusName { get; set; }
    }

}
