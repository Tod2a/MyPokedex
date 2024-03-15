using System.Text.Json.Serialization;

namespace MyPokedex.Data
{
    public class EncounterDetail
    {
        public int Chance { get; set; }
        [JsonPropertyName("condition_values")]
        public List<PokemonBase> ConditionValues { get; set; }
        [JsonPropertyName("max_level")]
        public int MaxLevel { get; set; }
        public Method Method { get; set; }
        [JsonPropertyName("min_level")]
        public int MinLevel { get; set; }
    }
}
