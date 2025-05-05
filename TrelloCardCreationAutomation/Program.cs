using System.Text;
using System.Text.Json;
using TrelloCardCreationAutomation.App;

namespace TrelloCardCreationAutomation
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            Dictionary<string, string> env = EnvReader.GetEnvSync();

            string cardsJsonFilePath = "C:\\Users\\Aneto\\Documents\\cards.json";
            string? apiKey;
            string? token;
            string idList = "67fd822eaf62439dc1f1f441";

            env.TryGetValue("TOKEN", out token);
            env.TryGetValue("APIKEY", out apiKey);

            string url = $"https://api.trello.com/1/cards?idList={idList}&key={apiKey}&token={token}";

            string fileContent = File.ReadAllText(cardsJsonFilePath);
            MainJsonDto? cardsJsonObject = JsonSerializer.Deserialize<MainJsonDto>(fileContent);

            if (cardsJsonObject == null) throw new Exception("error parsing json. returned null");
            if (cardsJsonObject.Cards == null) throw new Exception("error parsing cards array. returned null");
            if (cardsJsonObject.Cards.Count() == 0) throw new Exception("error parsing cards array. returned none");

            using HttpClient httpClient = new HttpClient();

            foreach (TrelloCardJsonDto card in cardsJsonObject.Cards)
            {
                CreateCardRequestBody body = new CreateCardRequestBody
                {
                    Name = card.Topic,
                    IdLabels = string.Join(",", card.LabelId)
                };
                string? jsonBody = JsonSerializer.Serialize<CreateCardRequestBody>(body);
                HttpResponseMessage? response = await httpClient.PostAsync(url, new StringContent(jsonBody, Encoding.UTF8, "application/json"));

                if (!response.IsSuccessStatusCode)
                {
                    Console.WriteLine($"Error: {response.StatusCode}");

                    string? responseContent = await response.Content.ReadAsStringAsync();
                    Console.WriteLine(responseContent);
                }
                else
                {
                    Console.WriteLine($"OK: '{card.Topic}' was created!");
                }
            }
        }
    }
}
