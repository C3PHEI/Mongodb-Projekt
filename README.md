Um die Datenbank im ersten schritt zu erstellen.
 Starten sie Skript.js in mongosh oder powershell

Dann solte die Datenbank erstellt sein und das Projekt kann getestet werden.

_________________________________________________________________________________

// backup der Datenbank SkiService erstellen 
mongodump --db=Skiservice --out=C:\SkiserviceBackup
 
//Backup restoren
mongorestore --db=BackupSkiservice --dir=C:\SkiserviceBackup\Skiservice
 
//Test ob backup richtig gespeichert ist 
use BackupSkiservice
show collections
