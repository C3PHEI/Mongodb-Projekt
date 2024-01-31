using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using Mongodb.Models;
using MongoExample.Models;

namespace Mongodb.Services
{
    public class MitarbeiterService
    {
        private readonly IMongoCollection<Mitarbeiter> _mitarbeiterCollection;

        public MitarbeiterService(IOptions<MongoDBSettings> mongoDBSettings)
        {
            var client = new MongoClient(mongoDBSettings.Value.ConnectionURI);
            var database = client.GetDatabase(mongoDBSettings.Value.DatabaseName);
            _mitarbeiterCollection = database.GetCollection<Mitarbeiter>(mongoDBSettings.Value.MitarbeiterCollectionName);
        }

        public async Task<List<string>> GetGueltigeMitarbeiterNamen()
        {
            var mitarbeiterListe = await _mitarbeiterCollection.Find(new BsonDocument()).ToListAsync();
            return mitarbeiterListe.Select(s => s.MitarbeiterName).ToList();
        }


    }
}
