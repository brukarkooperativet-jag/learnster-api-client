using System.Text.Json.Serialization;

namespace JAG.Learnster.APIClient.Models.ApiContracts
{
    /// <summary>
    /// VendorUsersVendorStudentSerializer
    /// </summary>
    public class VendorUsersVendorStudentSerializer
    {
        /// <summary>
        /// Gets or Sets Id
        /// </summary>
        [JsonPropertyName("id")]
        public Guid? Id { get; set; }

        /// <summary>
        /// Gets or Sets Vendor
        /// </summary>
        [JsonPropertyName("vendor")]
        public Guid? Vendor { get; set; }

        /// <summary>
        /// Gets or Sets User
        /// </summary>
        [JsonPropertyName("user")]
        public VendorUserShort User { get; set; }

        /// <summary>
        /// Gets or Sets Active
        /// </summary>
        [JsonPropertyName("active")]
        public bool? Active { get; set; }

        /// <summary>
        /// Gets or Sets CreatedDate
        /// </summary>
        [JsonPropertyName("created_date")]
        public DateTime? CreatedDate { get; set; }

        /// <summary>
        /// Gets or Sets ControlledByIntegration
        /// </summary>
        [JsonPropertyName("controlled_by_integration")]
        public bool? ControlledByIntegration { get; set; }

        /// <summary>
        /// Gets or Sets Deletable
        /// </summary>
        [JsonPropertyName("deletable")]
        public bool? Deletable { get; set; }

        /// <summary>
        /// Gets or Sets TaggedCount
        /// </summary>
        [JsonPropertyName("tagged_count")]
        public string TaggedCount { get; set; }
    }
}
