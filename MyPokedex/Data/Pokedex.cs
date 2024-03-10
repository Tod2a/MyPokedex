using System.Text.Json;
using static System.Net.WebRequestMethods;

namespace MyPokedex.Data
{
    public class Pokedex
    {
        public Pokemon SelectedPokemon { get; set; }
        public PokemonBase[] PokemonsList { get; set; }
        private DataManager Datas { get; set; } = new DataManager();


        public async Task GetPokemon()
        {
            JsonElement root = await Datas.GetRoot("https://pokeapi.co/api/v2/pokemon?limit=100000&offset=0");
            JsonElement pokemon = root.GetProperty("results");
            var options = Datas.GetOptionCaseInsensitive();
            PokemonsList = JsonSerializer.Deserialize<PokemonBase[]>(pokemon, options);
        }

        public async Task<IEnumerable<PokemonBase>> SearchByName(string searchText)
        {
            searchText = searchText.ToLower();
            var result = PokemonsList.Where(p => p.Name.ToLower().Contains(searchText));
            return await Task.FromResult(result);
        }

        public async Task GetPokemonInfos(string name)
        {
            Pokemon pokemon = new Pokemon { Name = name};
            string url = "https://pokeapi.co/api/v2/pokemon/" + name + "/";
            JsonElement root = await Datas.GetRoot(url);
            JsonElement order = root.GetProperty("order");
            pokemon.Order = JsonSerializer.Deserialize<int>(order);
            GetSprites(pokemon);
            SelectedPokemon = pokemon;
            Console.WriteLine(SelectedPokemon.Order);
        }

        private void GetSprites(Pokemon pokemon)
        {
            pokemon.Sprite = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/" + pokemon.Order + ".png";
            pokemon.ShinySprite = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/shiny/" + pokemon.Order + ".png";
        }
    }
}
