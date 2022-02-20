using System;
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

        // TODO: Use enum instead
        /// <summary>
        /// Gets or Sets Provider
        /// <remarks>Options: AzureAD, GSuiteSAML, GeneralSAML, AzureOpenID</remarks>
        /// </summary>
        [JsonPropertyName("provider")]
        public string Provider { get; set; }

        /// <summary>
        /// Gets or Sets ProviderCredentials. Unique Identifier for SSO
        /// </summary>
        [JsonPropertyName("provider_credentials")]
        public string ProviderCredentials { get; set; }
    }
}
