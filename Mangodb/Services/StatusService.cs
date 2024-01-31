using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Mongodb.Models;
using MongoExample.Models;
using MongoDB.Bson;
using Mongodb.Services;

namespace Mongodb.Services
{
    public class StatusService
    {
        private readonly IMongoCollection<Status> _statusCollection;

        public StatusService(IOptions<MongoDBSettings> mongoDBSettings)
        {
            var client = new MongoClient(mongoDBSettings.Value.ConnectionURI);
            var database = client.GetDatabase(mongoDBSettings.Value.DatabaseName);
            _statusCollection = database.GetCollection<Status>(mongoDBSettings.Value.StatusCollectionName);
        }

        public async Task<List<string>> GetGueltigeStatusNamen()
        {
            var statusListe = await _statusCollection.Find(new BsonDocument()).ToListAsync();
            return statusListe.Select(s => s.StatusName).ToList();
        }


    }

}
