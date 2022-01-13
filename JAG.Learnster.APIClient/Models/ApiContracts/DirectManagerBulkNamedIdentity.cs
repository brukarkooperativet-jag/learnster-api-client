using System.Text.Json.Serialization;

namespace JAG.Learnster.APIClient.Models.ApiContracts
{
    /// <summary>
    /// PublicDirectManagerBulkNamedIdentity
    /// </summary>
    public class DirectManagerBulkNamedIdentity
    {
        /// <summary>
        /// Gets or Sets VendorStudentId
        /// </summary>
        [JsonPropertyName("vendor_student_id")]
        public Guid? VendorStudentId { get; set; }
    }
}
