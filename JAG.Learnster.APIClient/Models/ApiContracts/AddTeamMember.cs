using System.Text.Json.Serialization;

namespace JAG.Learnster.APIClient.Models.ApiContracts
{
    /// <summary>
    /// PublicAddTeamMember
    /// </summary>
    public class AddTeamMember
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
        /// Gets or Sets IsManager
        /// </summary>
        [JsonPropertyName("is_manager")]
        public bool? IsManager { get; set; }

        /// <summary>
        /// Gets or Sets Members
        /// </summary>
        [JsonPropertyName("members")]
        public List<VendorUsersVendorStudentSerializer> Members { get; set; }

        /// <summary>
        /// Gets or Sets Managers
        /// </summary>
        [JsonPropertyName("managers")]
        public List<VendorUsersVendorStudentSerializer> Managers { get; set; }
    }
}
