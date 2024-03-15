using System.Text.Json.Serialization;

namespace MyPokedex.Data
{
    public class VersionDetail
    {
        [JsonPropertyName("encounter_details")]
        public List<EncounterDetail> EncounterDetails { get; set; }
        [JsonPropertyName("max_chance")]
        public int MaxChance { get; set; }
        public Version Version { get; set; }
    }
}
