using System.Text.Json.Serialization;

namespace MyPokedex.Data
{
    public class RootEncounter
    {
        [JsonPropertyName("location_area")]
        public LocationArea LocationArea { get; set; }
        [JsonPropertyName("version_details")]
        public List<VersionDetail> VersionDetails { get; set; }
    }
}
