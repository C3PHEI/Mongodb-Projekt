// backup der Datenbank SkiService erstellen 
mongodump --db=Skiservice --out=C:\SkiserviceBackup
 
//Backup restoren
mongorestore --db=BackupSkiservice --dir=C:\SkiserviceBackup\Skiservice
 
//Test ob backup richtig gespeichert ist 
use BackupSkiservice
show collections
