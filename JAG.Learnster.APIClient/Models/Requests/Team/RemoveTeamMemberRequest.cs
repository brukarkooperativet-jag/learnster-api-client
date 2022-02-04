using System;
using System.Text.Json.Serialization;

namespace JAG.Learnster.APIClient.Models.Requests.Team
{
    public class RemoveTeamMemberRequest
    {
        /// <summary>
        /// Gets or Sets VendorStudentId
        /// </summary>
        [JsonPropertyName("vendor_student_id")]
        public Guid StudentId { get; set; }
    }
}