using Xunit;
using MyPokedex;
using MyPokedex.Data;
using static System.Net.WebRequestMethods;
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
    }
}