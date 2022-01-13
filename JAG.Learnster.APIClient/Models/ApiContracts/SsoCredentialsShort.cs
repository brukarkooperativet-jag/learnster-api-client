using System.Text.Json.Serialization;

namespace JAG.Learnster.APIClient.Models.ApiContracts
{
    /// <summary>
    /// PublicSSOCredentialsShort
    /// </summary>
    public class SsoCredentialsShort
    {
        /// <summary>
        /// Gets or Sets Id
        /// </summary>
        [JsonPropertyName("id")]
        public Guid? Id { get; set; }

        /// <summary>
        /// Gets or Sets Provider
        /// </summary>
        [JsonPropertyName("provider")]
        public string Provider { get; set; }

        /// <summary>
        /// Gets or Sets ProviderCredentials
        /// </summary>
        [JsonPropertyName("provider_credentials")]
        public string ProviderCredentials { get; set; }
    }
}
