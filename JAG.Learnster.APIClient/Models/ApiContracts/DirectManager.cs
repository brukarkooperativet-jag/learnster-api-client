using System.Text.Json.Serialization;

namespace JAG.Learnster.APIClient.Models.ApiContracts
{
    /// <summary>
    /// PublicDirectManager
    /// </summary>
    public class DirectManager
    {
        /// <summary>
        /// Gets or Sets Id
        /// </summary>
        [JsonPropertyName("id")]
        public Guid? Id { get; set; }

        /// <summary>
        /// Gets or Sets Name
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or Sets Description
        /// </summary>
        [JsonPropertyName("description")]
        public string Description { get; set; }

        /// <summary>
        /// Gets or Sets CreatedDate
        /// </summary>
        [JsonPropertyName("created_date")]
        public DateTime? CreatedDate { get; set; }

        /// <summary>
        /// Gets or Sets AllowDiscussion
        /// </summary>
        [JsonPropertyName("allow_discussion")]
        public bool? AllowDiscussion { get; set; }

        /// <summary>
        /// Gets or Sets IsAdminOnly
        /// </summary>
        [JsonPropertyName("is_admin_only")]
        public bool? IsAdminOnly { get; set; }

        /// <summary>
        /// Gets or Sets VendorStudent
        /// </summary>
        [JsonPropertyName("vendor_student")]
        public VendorStudent VendorStudent { get; set; }
    }
}
