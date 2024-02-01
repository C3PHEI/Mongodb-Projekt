// Verbindung zur MongoDB-Instanz herstellen
// Ersetze 'mongodb://localhost:27017' mit deiner MongoDB-Verbindungszeichenfolge, falls notwendig
var db = connect('mongodb://localhost:27017/Skiservice');

// Benutzer
db.Benutzer.insertMany([
    {
        "BenutzerID": 1, 
        "Benutzername": "Maximilian", 
        "Passwort": "max123", 
        "MitarbeiterID": 1, 
        "Blockiert": true
    }, 
    {
        "BenutzerID": 2, 
        "Benutzername": "Tyrone", 
        "Passwort": "tyr123", 
        "MitarbeiterID": 2, 
        "Blockiert": false
    }, 
    {
        "BenutzerID": 3, 
        "Benutzername": "Leon", 
        "Passwort": "leo123", 
        "MitarbeiterID": 3, 
        "Blockiert": false
    }, 
    {
        "BenutzerID": 4, 
        "Benutzername": "Emma", 
        "Passwort": "emm123", 
        "MitarbeiterID": 4, 
        "Blockiert": false
    }, 
    {
        "BenutzerID": 5, 
        "Benutzername": "Lukas", 
        "Passwort": "luk123", 
        "MitarbeiterID": 5, 
        "Blockiert": false
    }, 
    {
        "BenutzerID": 6, 
        "Benutzername": "Elise", 
        "Passwort": "eli123", 
        "MitarbeiterID": 6, 
        "Blockiert": false
    }, 
    {
        "BenutzerID": 7, 
        "Benutzername": "Olivier", 
        "Passwort": "oli123", 
        "MitarbeiterID": 7, 
        "Blockiert": false
    }, 
    {
        "BenutzerID": 8, 
        "Benutzername": "Amelie", 
        "Passwort": "ame123", 
        "MitarbeiterID": 8, 
        "Blockiert": false
    }, 
    {
        "BenutzerID": 9, 
        "Benutzername": "Louis", 
        "Passwort": "lou123", 
        "MitarbeiterID": 9, 
        "Blockiert": false
    }, 
    {
        "BenutzerID": 10, 
        "Benutzername": "Hugo", 
        "Passwort": "hug123", 
        "MitarbeiterID": 10, 
        "Blockiert": false
    }
]);


// Mitarbeiter
db.Mitarbeiter.insertMany([
    {
        "MitarbeiterID": 1, 
        "MitarbeiterName": "Maximilian"
    },
    {
        "MitarbeiterID": 2, 
        "MitarbeiterName": "Tyrone"
    },
    {
        "MitarbeiterID": 3, 
        "MitarbeiterName": "Leon"
    },
    {
        "MitarbeiterID": 4, 
        "MitarbeiterName": "Emma"
    },
    {
        "MitarbeiterID": 5, 
        "MitarbeiterName": "Lukas"
    },
    {
        "MitarbeiterID": 6, 
        "MitarbeiterName": "Elise"
    },
    {
        "MitarbeiterID": 7, 
        "MitarbeiterName": "Olivier"
    },
    {
        "MitarbeiterID": 8, 
        "MitarbeiterName": "Amelie"
    },
    {
        "MitarbeiterID": 9, 
        "MitarbeiterName": "Louis"
    },
    {
        "MitarbeiterID": 10, 
        "MitarbeiterName": "Hugo"
    }
]);


// Bestellungen
db.Bestellungen.insertMany([
    {
        "BestellungsID": 1, 
        "Prioritaet": "Express (-2)", 
        "Service": "Kleiner Service", 
        "Name": "Ronald", 
        "Email": "Ronald.Weasley@Hogwarts.uk", 
        "Telefon": "+41 78 123 45 67", 
        "DatumEinreichung": "2024-01-03", 
        "DatumBisFertig": "2024-01-06", 
        "Preis": 65.0, 
        "StatusName": "Offen", 
        "MitarbeiterName": "Maximilian"
    },
    {
        "BestellungsID": 2, 
        "Prioritaet": "Standart (+/-0)", 
        "Service": "Bindung montieren und einstellen", 
        "Name": "Donald", 
        "Email": "Donald.Duck@ente.haus", 
        "Telefon": "+41 79 234 56 78", 
        "DatumEinreichung": "2023-12-23", 
        "DatumBisFertig": "2024-01-07", 
        "Preis": 30.0, 
        "StatusName": "In-Arbeit", 
        "MitarbeiterName": "Elise"
    },
    {
        "BestellungsID": 3, 
        "Prioritaet": "Tief (+5)", 
        "Service": "Kleiner Service", 
        "Name": "Nathan", 
        "Email": "Nathan.blin@gmx.com", 
        "Telefon": "+41 79 254 59 69", 
        "DatumEinreichung": "2024-01-17", 
        "DatumBisFertig": "2024-01-24", 
        "Preis": 110.0, 
        "StatusName": "Storniert", 
        "MitarbeiterName": "Tyrone"
    },
    {
        "BestellungsID": 4, 
        "Prioritaet": "Express (-2)", 
        "Service": "Heisswachsen", 
        "Name": "Hermione", 
        "Email": "Hermione.Granger@Hogwarts.uk", 
        "Telefon": "+41 80 615 79 31", 
        "DatumEinreichung": "2024-01-02", 
        "DatumBisFertig": "2024-01-10", 
        "Preis": 50.0, 
        "StatusName": "Abgeschlossen", 
        "MitarbeiterName": "Emma"
    }
]);

// Status
db.Status.insertMany([
    {
        "StatusID": 1, 
        "StatusName": "Offen"
    }, 
    {
        "StatusID": 2, 
        "StatusName": "In-Arbeit"
    }, 
    {
        "StatusID": 3, 
        "StatusName": "Abgeschlossen"
    }, 
    {
        "StatusID": 4, 
        "StatusName": "Storniert"
    }
]);

print('Datenbank, Collections und Daten erfolgreich erstellt.');
