﻿using QualifoodSchlachtdatenUploadSwClient.SchlachtdatenUploadSW;

var client = new SchlachtdatenUploadSWClient(SchlachtdatenUploadSWClient.EndpointConfiguration
    .BasicHttpBinding_ISchlachtdatenUploadSW);
client.ClientCredentials.UserName.UserName = "BENUTZERNAME"; // TODO: anpassen
client.ClientCredentials.UserName.Password = "PASSWORT"; // TODO: anpassen

// Create the data object
var requestData = new SchlachtdatenSwDto()
{
    Schlachtdatum = DateTime.Today, // TODO: anpassen
    SchlachthofBetriebsnummer = "BALISNUMMER", // TODO: anpassen
    SchlachthofInterneNummer = -1, // TODO: anpassen
    SchlachtdatenSw = new[]
    {
        new SchlachtdatenSwPosDto()
        {
            Schlachtnummer = 1,
            Befunde =
                new[]
                {
                    new Befunddaten() { Befundcode = 123, Befundgruppe = 1 },
                    new Befunddaten() { Befundcode = 456, Befundgruppe = 1 }
                },
            Bemerkung = "",
            Beschauart = Beschauarten.Konventionell,
            Datenherkunft = DatenherkunftDTO.Hennessy,
            Eichspeichernummer = "123",
            Nettogewicht = 110,
            Produktionsart = ProduktionsartSW_DTO.Mastschwein,
            Taetowierung = "de123",
            Klassifizierername = "Name",
            LandwirtBetriebsnummer = "276091212121212",
            LieferantBetriebsnummer = "276091212121212",
            SchlachtbetriebBetriebsnummer = "276091212121212",
            SpeditionsBetriebsnummer = "276091212121212",
            Schlachtungsart = SchlachtungsartDTO.Auftragsschlachtung,
        }
    }
};


await client.UploadSwV2Async(requestData);
