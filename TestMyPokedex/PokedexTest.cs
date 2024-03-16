using MyPokedex.Data;
namespace TestMyPokedex
{
    public class PokedexTest
    {
        [Theory]
        [InlineData(0, "bulbasaur")]
        [InlineData(1, "ivysaur")]
        [InlineData(2, "venusaur")]
        public async Task TestGetPokemon(int id, string expected)
        {
            //Arrange
            Pokedex pokedex = new Pokedex();
            //Act
            await pokedex.GetPokemon();
            var myResult = pokedex.PokemonsList[id].Name;
            //Assert
            Assert.Equal(expected, myResult);
        }

        [Theory]
        [InlineData("bulba", "bulbasaur")]
        [InlineData("artyui", null)]
        public async Task TestSearchbyName(string test, string expected)
        {
            //Arrange
            var pokedex = new Pokedex();
            //Act
            await pokedex.GetPokemon();
            string myResult;
            var tempResult = pokedex.SearchByName(test).Result.FirstOrDefault();
            if (tempResult != null)
            {
                myResult = tempResult.Name;
            }
            else { myResult = null; }
            //Assert
            Assert.Equal(expected, myResult);
        }

        [Fact]
        public async Task TestGetPokemonInfo()
        {
            //Arrange
            var pokedex = new Pokedex();
            //Act
            await pokedex.GetPokemonInfos("bulbasaur");
            var myName = pokedex.SelectedPokemon.Name;
            var myType = pokedex.SelectedPokemon.Type;
            var myHeight = pokedex.SelectedPokemon.Height;
            var myWeight = pokedex.SelectedPokemon.Weight;
            var mySprite = pokedex.SelectedPokemon.Sprite;
            var myFirstStatName = pokedex.SelectedPokemon.Stats[0].Name;
            var myFirstStatBase = pokedex.SelectedPokemon.Stats[0].BaseStat;
            //Assert
            Assert.Equal("bulbasaur", myName);
            Assert.Equal("grass/poison", myType);
            Assert.Equal(0.7, myHeight);
            Assert.Equal(6.9, myWeight);
            Assert.Equal("https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/1.png", mySprite);
            Assert.Equal("hp", myFirstStatName);
            Assert.Equal(45, myFirstStatBase);
        }

        [Fact]
        public async Task TestAddFavs()
        {
            //Arrange
            var pokedex = new Pokedex();
            //Act
            await pokedex.GetPokemonInfos("bulbasaur");
            pokedex.AddFavorite();
            var myResult = pokedex.Favorites[0].Name;
            //Assert
            Assert.Equal("bulbasaur", myResult);
        }

        [Fact]
        public async Task TestAddFavs2()
        {
            //Arrange
            var pokedex = new Pokedex();
            //Act
            await pokedex.GetPokemonInfos("bulbasaur");
            pokedex.AddFavorite();
            await pokedex.GetPokemonInfos("bulbasaur");
            var myResult = pokedex.AddFavorite();
            //Assert
            Assert.False(myResult);
        }

        [Fact]
        public async Task TestAddFavs3()
        {
            //Arrange
            var pokedex = new Pokedex();
            //Act
            List<string> list = new List<string> {
                "bulbasaur",
                "ivysaur",
                "venusaur",
                "charmander",
                "charmeleon",
                "charizard",
                "squirtle",
                "wartortle",
                "blastoise",
                "caterpie",
                "metapod",
                "butterfree",
                "weedle",
                "kakuna",
                "beedrill"
            };
            foreach (string item in list)
            {
                await pokedex.GetPokemonInfos(item);
                pokedex.AddFavorite();
            }
            await pokedex.GetPokemonInfos("pidgey");
            var myResult = pokedex.AddFavorite();
            //Assert
            Assert.False(myResult);
        }

        [Fact]
        public async Task testRemoveFavs()
        {
            //Arrange
            var pokedex = new Pokedex();
            //Act
            await pokedex.GetPokemonInfos("bulbasaur");
            pokedex.AddFavorite();
            await pokedex.GetPokemonInfos("ivysaur");
            pokedex.AddFavorite();
            pokedex.RemoveFavorite("bulbasaur");
            var myResult = pokedex.Favorites[0].Name;
            //Assert
            Assert.Equal("ivysaur", myResult);
        }
    }
}