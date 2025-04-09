using QualifoodSchlachtdatenUploadSwClient;

var userName = "BENUTZERNAME"; // TODO: anpassen
var password = "PASSWORT"; // TODO: anpassen

var result = await Schlachtdaten.Upload(userName, password);

if (result)
    await Betriebsdaten.Upload(userName, password);
