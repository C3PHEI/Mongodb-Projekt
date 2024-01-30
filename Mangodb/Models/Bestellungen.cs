using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;

namespace MongoExample.Models
{
    public class Bestellungen
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("BestellungsID")]
        public int BestellungsID { get; set; }

        [BsonElement("Prioritaet")]
        public string? Prioritaet { get; set; }

        [BsonElement("Service")]
        public string? Service { get; set; }

        [BsonElement("Name")]
        public string? Name { get; set; }

        [BsonElement("Email")]
        public string? Email { get; set; }

        [BsonElement("Telefon")]
        public string? Telefon { get; set; }

        [BsonElement("DatumEinreichung")]
        public DateTime DatumEinreichung { get; set; }

        [BsonElement("DatumBisFertig")]
        public DateTime DatumBisFertig { get; set; }

        [BsonElement("Preis")]
        public double Preis { get; set; }

        [BsonElement("StatusName")]
        public string? StatusName { get; set; }

        [BsonElement("MitarbeiterName")]
        public string MitarbeiterName { get; set; }
    }
}


