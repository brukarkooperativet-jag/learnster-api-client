using System;
using System.Text.Json.Serialization;

namespace JAG.Learnster.APIClient.Models.Requests.Team
{
    public class AddTeamMemberRequest
    {
        /// <summary>
        /// Gets or Sets VendorStudentId
        /// </summary>
        [JsonPropertyName("vendor_student_id")]
        public Guid StudentId { get; set; }

        /// <summary>
        /// Gets or Sets IsManager
        /// </summary>
        [JsonPropertyName("is_manager")]
        public bool IsManager { get; set; }
    }
}