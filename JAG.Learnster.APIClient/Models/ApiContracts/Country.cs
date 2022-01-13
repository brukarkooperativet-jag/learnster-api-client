using System.Text.Json.Serialization;

namespace JAG.Learnster.APIClient.Models.ApiContracts
{
    /// <summary>
    /// PublicCountry
    /// </summary>
    public class Country
    {
        /// <summary>
        /// Gets or Sets Id
        /// </summary>
        [JsonPropertyName("id")]
        public int? Id { get; set; }

        /// <summary>
        /// Gets or Sets Name
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or Sets Iso3
        /// </summary>
        [JsonPropertyName("iso3")]
        public string Iso3 { get; set; }

        /// <summary>
        /// Gets or Sets Iso2
        /// </summary>
        [JsonPropertyName("iso2")]
        public string Iso2 { get; set; }
    }
}
