using Microsoft.AspNetCore.Mvc;

namespace MongoExample.Models;

public class MongoDBSettings
{
    public string ConnectionURI { get; set; } = null!;
    public string DatabaseName { get; set; } = null!;
    public string BestellungCollectionName { get; set; } = null!;
    public string StatusCollectionName { get; set; } = null!;
    public string MitarbeiterCollectionName { get; set; } = null!;
}

