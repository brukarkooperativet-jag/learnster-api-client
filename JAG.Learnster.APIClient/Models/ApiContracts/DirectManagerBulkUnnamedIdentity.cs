using System.Text.Json.Serialization;

namespace JAG.Learnster.APIClient.Models.ApiContracts
{
    /// <summary>
    /// PublicDirectManagerBulkUnnamedIdentity
    /// </summary>
    public class DirectManagerBulkUnnamedIdentity
    {
        /// <summary>
        /// Gets or Sets Id
        /// </summary>
        [JsonPropertyName("id")]
        public Guid? Id { get; set; }
    }
}
