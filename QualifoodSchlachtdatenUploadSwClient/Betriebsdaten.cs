using QualifoodSchlachtdatenUploadSwClient.BetriebsdatenService;

namespace QualifoodSchlachtdatenUploadSwClient;

public class Betriebsdaten
{
    public async static Task Upload(string userName, string password)
    {
        var client = new BetriebsdatenServiceClient(BetriebsdatenServiceClient.EndpointConfiguration
            .BasicHttpBinding_IBetriebsdatenService);
        client.ClientCredentials.UserName.UserName = userName;
        client.ClientCredentials.UserName.Password = password;

        // Sollte ein Betrieb in mehreren Rollen, also z.B.: als Landwirt und Lieferant
        // auftreten, muss er für jede Rolle hochgeladen werden.

        var landwirt1 = new Stammdaten()
        {
            Betriebsnummer = "276091212121212", Name1 = "Hans Huber", Email = "hans.huber@example.de",
        };

        await client.SendStammdatenAsync(StammdatenRolle.Landwirt, new[] { landwirt1 }, "extern");

        var lieferant1 = new Stammdaten()
        {
            Betriebsnummer = "276091212121212", Name1 = "Hans Huber", Email = "hans.huber@example.de",
        };

        await client.SendStammdatenAsync(StammdatenRolle.Landwirt, new[] { lieferant1 }, "extern");

        var schlachtbetrieb1 = new Stammdaten()
        {
            Betriebsnummer = "276091212121212", Name1 = "Hans Huber", Email = "hans.huber@example.de",
        };

        await client.SendStammdatenAsync(StammdatenRolle.Schlachtbetrieb, new[] { schlachtbetrieb1 }, "extern");
    }
}
