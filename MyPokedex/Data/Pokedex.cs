using System.Text.Json;
using static System.Net.WebRequestMethods;

namespace MyPokedex.Data
{
    public class Pokedex
    {
        public Pokemon SelectedPokemon { get; set; }
        public List<Pokemon> Favorites { get; set; } = new List<Pokemon>();
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
            JsonElement id = root.GetProperty("id");
            pokemon.Id = JsonSerializer.Deserialize<int>(id);
            GetSprites(pokemon);
            SelectedPokemon = pokemon;
        }

        private void GetSprites(Pokemon pokemon)
        {
            pokemon.Sprite = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/" + pokemon.Id + ".png";
            pokemon.ShinySprite = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/shiny/" + pokemon.Id + ".png";
        }

        public bool AddFavorite()
        {
            if (Favorites.Count < 15) 
            { 
                Favorites.Add(SelectedPokemon); 
                return true;
            }
            return false; 
        }

        public bool RemoveFavorite(string name) 
        { 
            Pokemon poke = Favorites.Where(x => x.Name.ToLower().Contains(name)).FirstOrDefault();
            if (poke != null)
            {
                Favorites.Remove(poke);
                return true;
            }
            return false;
        }
    }
}
