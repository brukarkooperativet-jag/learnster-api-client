using System.Text.Json.Serialization;

namespace JAG.Learnster.APIClient.Models.ApiContracts
{
    /// <summary>
    /// PublicRemoveTeamMember
    /// </summary>
    public class RemoveTeamMember
    {
        /// <summary>
        /// Gets or Sets Id
        /// </summary>
        [JsonPropertyName("id")]
        public Guid? Id { get; set; }

        /// <summary>
        /// Gets or Sets VendorStudentId
        /// </summary>
        [JsonPropertyName("vendor_student_id")]
        public Guid? VendorStudentId { get; set; }

        /// <summary>
        /// Gets or Sets Members
        /// </summary>
        [JsonPropertyName("members")]
        public List<VendorStudent> Members { get; set; }

        /// <summary>
        /// Gets or Sets Managers
        /// </summary>
        [JsonPropertyName("managers")]
        public List<VendorStudent> Managers { get; set; }
    }
}
