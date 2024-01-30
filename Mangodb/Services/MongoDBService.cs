using MongoExample.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoDB.Bson;

namespace MongoExample.Services;

public class MongoDBService
{
    private readonly IMongoCollection<Bestellungen> _klasseCollection; 

    public MongoDBService(IOptions<MongoDBSettings> mongoDBSettings)
    {
        MongoClient client = new MongoClient(mongoDBSettings.Value.ConnectionURI); 
        IMongoDatabase database = client.GetDatabase(mongoDBSettings.Value.DatabaseName);
        _klasseCollection = database.GetCollection<Bestellungen>(mongoDBSettings.Value.CollectionName);
    }

    public async Task CreateAsync(Bestellungen klasse)
    {
        await _klasseCollection.InsertOneAsync(klasse);
        return;
    }
    // noch anpassen

    public async Task<List<Bestellungen>> GetAsync()
    {
        return await _klasseCollection.Find(new BsonDocument()).ToListAsync();
    }

    public async Task<Bestellungen> GetAsyncId(string id)
    {
        var filter = Builders<Bestellungen>.Filter.Eq("Id", id);
        return await _klasseCollection.Find(filter).FirstOrDefaultAsync();
    }


    public async Task AddToKlasseAsync(string id,string Klassenlehrer)
    {
        FilterDefinition<Bestellungen> filter = Builders<Bestellungen>.Filter.Eq("Id", id);
        UpdateDefinition<Bestellungen> update = Builders<Bestellungen>.Update.AddToSet<string>("Klassenlehrer", Klassenlehrer);
        await _klasseCollection.UpdateOneAsync(filter, update);
        return;
    }
    // noch anpassen

    public async Task DeteleAsync(string id)
    {
        FilterDefinition<Bestellungen> filter = Builders<Bestellungen>.Filter.Eq("Id", id);
        await _klasseCollection.DeleteOneAsync(filter);
        return;
    } 
    // noch anpassen
}

