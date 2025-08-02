using Newtonsoft.Json.Linq;
using RestSharp;

internal class Program
{
    private const string ClientId = "YOUR_CLIENT";
    private const string ClientSecret = "";

    private static async Task Main(string[] args)
    {
        string token = await GetAccessTokenAsync();
        if (string.IsNullOrEmpty(token))
        {
            Console.WriteLine("Failed to retrieve access token.");
            return;
        }
        Console.WriteLine($"Access Token: {token}");
        await GetPlayableRacesAsync(token);

        Console.WriteLine("Press any key to exit...");
        Console.ReadKey();
    }

    private static async Task<string?> GetAccessTokenAsync()
    {
        var client = new RestClient("https://us.battle.net/oauth/token");

        var request = new RestRequest { Method = Method.Post };

        string basicAuthValue = Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes($"{ClientId}:{ClientSecret}"));

        request.AddHeader("Authorization", $"Basic {basicAuthValue}");
        request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
        request.AddParameter("grant_type", "client_credentials");

        var response = await client.ExecuteAsync(request);

        if (!response.IsSuccessful || response.Content == null)
        {
            Console.WriteLine($"Error: {response.ErrorMessage}");
            return null;
        }

        var json = JObject.Parse(response.Content);
        return json["access_token"]?.ToString();
    }

    private static async Task GetPlayableRacesAsync(string token)
    {
        Console.WriteLine("Buscando Lista");

        var client = new RestClient("https://us.api.blizzard.com");
        var request = new RestRequest("data/wow/playable-race/index", Method.Get);
        request.AddParameter("namespace", "static-us");
        request.AddParameter("locale", "pt_BR");
        request.AddParameter("access_token", token);

        var response = await client.ExecuteAsync(request);
        if (!response.IsSuccessful || response.Content == null)
        {
            Console.WriteLine($"Erro ao buscar: {response.ErrorMessage}");
            return;
        }
        var json = JObject.Parse(response.Content);
        Console.WriteLine("Lista de Raças Jogáveis:");
        var races = json["races"];
        if (races == null)
        {
            Console.WriteLine("Nenhuma raça encontrada.");
            return;
        }

        foreach (var race in races)
        {
            int id = race["id"]?.ToObject<int>() ?? 0;
            string nome = race["name"]?.ToString() ?? "Desconhecido";
            Console.WriteLine($"ID: {id}, Nome: {nome}");
        }
    }
}