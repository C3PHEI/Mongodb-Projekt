using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace Mongodb.Models
{
    public class Login
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("BenutzerID")]
        public int BenutzerID { get; set; }

        [BsonElement("Benutzername")]
        public string Benutzername { get; set; }

        [BsonElement("Passwort")]
        public string Passwort { get; set; }

        [BsonElement("MitarbeiterID")]
        public int MitarbeiterID { get; set; }

        [BsonElement("Blockiert")]
        public bool Blockiert { get; set; }
    }
}
