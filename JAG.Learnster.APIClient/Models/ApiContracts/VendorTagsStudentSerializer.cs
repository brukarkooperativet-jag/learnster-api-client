using System.Text.Json.Serialization;

namespace JAG.Learnster.APIClient.Models.ApiContracts
{
    /// <summary>
    /// PublicVendorTagsStudentSerializer
    /// </summary>
    public class VendorTagsStudentSerializer
    {
        /// <summary>
        /// Gets or Sets Id
        /// </summary>
        [JsonPropertyName("id")]
        public Guid? Id { get; set; }

        /// <summary>
        /// Gets or Sets User
        /// </summary>
        [JsonPropertyName("user")]
        public VendorTagsUserSerializer User { get; set; }

        /// <summary>
        /// Gets or Sets TaggedCount
        /// </summary>
        [JsonPropertyName("tagged_count")]
        public string TaggedCount { get; set; }
    }
}
