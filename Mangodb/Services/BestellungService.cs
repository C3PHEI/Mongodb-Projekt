using MongoExample.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoDB.Bson;
using MongoDB.Driver.Core.Bindings;
using Mongodb.Services;

namespace MongoExample.Services;

public class BestellungService
{
    // Setzt fest welche services eingeben werden können 
    private readonly List<string> gueltigeServices = new List<string>
        {
            "Kleiner Service",
            "Grosser Service",
            "Rennski-Service",
            "Bindung montieren und einstellen",
            "Fell zuschneiden",
            "Heisswachsen"
        };
    //* Setzt fest welcher Status von der Bestellung eingeben werden kann
    //private readonly List<string> gueltigeStatus = new List<string>
    //    {
    //        "Offen",
    //        "In-Arbeit",
    //        "Stoniert",
    //        "Abgeschlossen"
    //    };
    //*

    private readonly IMongoCollection<Bestellungen> _klasseCollection;
    private readonly StatusService _statusService;
    private readonly MitarbeiterService _mitarbeiterService;

    public BestellungService(IOptions<MongoDBSettings> mongoDBSettings, StatusService statusService, MitarbeiterService mitarbeiterService)
    {
        MongoClient client = new MongoClient(mongoDBSettings.Value.ConnectionURI);
        IMongoDatabase database = client.GetDatabase(mongoDBSettings.Value.DatabaseName);
        _klasseCollection = database.GetCollection<Bestellungen>(mongoDBSettings.Value.BestellungCollectionName);
        _statusService = statusService;
        _mitarbeiterService = mitarbeiterService;
    }

    // POST Service um eine Bestellung erstellen zukönnen
    public async Task CreateAsync(Bestellungen bestellungen)
    {
        await _klasseCollection.InsertOneAsync(bestellungen);
        return;
    }
    // TODO noch anpassen

    // GET Service um nach Bestellung suchen zukönnen
    public async Task<List<Bestellungen>> GetAsync()
    {
        return await _klasseCollection.Find(new BsonDocument()).ToListAsync();
    }

    // GET Service um nach Bestellung mit Id suchen zukönnen
    public async Task<Bestellungen> GetAsyncId(string id)
    {
        var filter = Builders<Bestellungen>.Filter.Eq("Id", id);
        return await _klasseCollection.Find(filter).FirstOrDefaultAsync();
    }

    // Holen der gültigen Statusnamen aus StatusService
    public async Task<List<string>> GetGueltigeStatusNamen()
    {
        return await _statusService.GetGueltigeStatusNamen();
    }

    // PUT Service um =Bestellung mit Id updaten zukönnen
    public async Task UpdateBestellungAsync(string id, Bestellungen bestellungen)
    {
        // Gibt eine fehler falls der Service nicht existiert
        if (!gueltigeServices.Contains(bestellungen.Service))
        {
            throw new ArgumentException("Ungültiger Service." +
                "\n\nBenutzen Sie eine Von diesen eingaben:" +
                "\n - Kleiner Service" +
                "\n - Grosser Service" +
                "\n - Rennski-Service" +
                "\n - Bindung montieren und einstellen" +
                "\n - Fell zuschneiden" +
                "\n - Heisswachsen");
        }

        var gueltigeStatusNamen = await _statusService.GetGueltigeStatusNamen();

        // Gibt eine fehler falls der Status nicht existiert
        if (!gueltigeStatusNamen.Contains(bestellungen.StatusName))
        {
            throw new ArgumentException("Ungültiger StatusName." +
                "\n\nBenutzen Sie eine Von diesen eingaben:" +
                "\n - Offen" +
                "\n - In - Arbeit" +
                "\n - Abgeschlossen" +
                "\n - Storniert");
        }

        var gueltigeMitarbeiterNamen = await _mitarbeiterService.GetGueltigeMitarbeiterNamen();

        // Gibt eine fehler falls der Mitarbeiter nicht existiert
        if (!gueltigeMitarbeiterNamen.Contains(bestellungen.MitarbeiterName))
        {
            throw new ArgumentException("Ungültiger MitarbeiterName.");
        }

        var filter = Builders<Bestellungen>.Filter.Eq("_id", new ObjectId(id));
        var update = Builders<Bestellungen>.Update
            .Set(b => b.Service, bestellungen.Service)
            .Set(b => b.Name, bestellungen.Name)
            .Set(b => b.Prioritaet, bestellungen.Prioritaet)
            .Set(b => b.Email, bestellungen.Email)
            .Set(b => b.Telefon, bestellungen.Telefon)
            .Set(b => b.DatumEinreichung, bestellungen.DatumEinreichung)
            .Set(b => b.DatumBisFertig, bestellungen.DatumBisFertig)
            .Set(b => b.Preis, bestellungen.Preis)
            .Set(b => b.StatusName, bestellungen.StatusName)
            .Set(b => b.MitarbeiterName, bestellungen.MitarbeiterName)
            ;

        await _klasseCollection.UpdateOneAsync(filter, update);
    }

    // DELETE Service um Bestellung mit Id löschen zukönnen
    public async Task DeteleAsync(string id)
    {
        FilterDefinition<Bestellungen> filter = Builders<Bestellungen>.Filter.Eq("Id", id);
        await _klasseCollection.DeleteOneAsync(filter);
        return;
    } 
}

