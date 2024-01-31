using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace Mongodb.Models
{
    public class Mitarbeiter
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("MitarbeiterID")]
        public int MitarbeiterID { get; set; }

        [BsonElement("MitarbeiterName")]
        public string MitarbeiterName { get; set; }
    }
}
