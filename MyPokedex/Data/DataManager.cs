using System.Text.Json;

namespace MyPokedex.Data
{
    public class DataManager
    {

        public JsonSerializerOptions GetOptionCaseInsensitive()
        {
            return new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
        }

        public async Task<JsonElement> GetRoot(string url)
        {
            var api = await GetStringApi(url);
            JsonDocument jsonDocument = JsonDocument.Parse(api);
            JsonElement root = jsonDocument.RootElement;
            return root;
        }


        private async Task<string> GetStringApi(string url)
        {
            try
            {
                HttpClient client = new HttpClient();

                return await client.GetStringAsync(url);
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Erreur de requête HTTP : {ex.Message}");
                return "";
            }

        }
    }
}
