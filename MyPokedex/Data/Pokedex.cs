using System.Text.Json;

namespace MyPokedex.Data
{
    public class Pokedex
    {
        public Pokemon[] Pokemons { get; set; }
        private DataManager Datas { get; set; } = new DataManager();


        public async Task GetPokemon()
        {
            JsonElement root = await Datas.GetRoot("https://pokeapi.co/api/v2/pokemon?limit=100000&offset=0");
            JsonElement pokemon = root.GetProperty("results");
            var options = Datas.GetOptionCaseInsensitive();
            Pokemons = JsonSerializer.Deserialize<Pokemon[]>(pokemon, options);

        }

    }
}
