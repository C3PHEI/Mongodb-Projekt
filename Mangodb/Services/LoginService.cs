using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using MongoDB.Driver;
using MongoDB.Bson;
using Mongodb.Models;

public class LoginService
{
    private readonly IConfiguration _configuration;
    private readonly IMongoCollection<Login> _logins;

    public LoginService(IConfiguration configuration)
    {
        var mongoDBSettings = configuration.GetSection("MongoDB");
        var connectionString = mongoDBSettings["ConnectionURI"];
        var databaseName = mongoDBSettings["DatabaseName"];
        var loginCollectionName = mongoDBSettings["LoginCollectionName"];

        var client = new MongoClient(connectionString);
        var database = client.GetDatabase(databaseName);
        _logins = database.GetCollection<Login>(loginCollectionName);
        _configuration = configuration;
    }

    public Login Authenticate(string username, string password)
    {
        var user = _logins.Find(user => user.Benutzername == username && user.Passwort == password).FirstOrDefault();

        // Überprüfen, ob der Benutzer existiert und nicht blockiert ist
        if (user == null || user.Blockiert)
        {
            return null;
        }
        return user;
    }


    public string GenerateJwtToken(string username)
    {
        var secret = _configuration.GetSection("JwtConfig:Secret").Value;
        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secret));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        var claims = new[] {
        new Claim(ClaimTypes.Name, username),
        // Sicherheitswarnung: Passwort sollte hier nicht inkludiert werden
    };

        var token = new JwtSecurityToken(
            claims: claims,
            expires: DateTime.Now.AddHours(3),
            signingCredentials: credentials
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}

