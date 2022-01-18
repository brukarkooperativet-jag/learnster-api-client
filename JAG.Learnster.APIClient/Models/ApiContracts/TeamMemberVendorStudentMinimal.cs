using System;
using System.Text.Json.Serialization;

namespace JAG.Learnster.APIClient.Models.ApiContracts
{
    /// <summary>
    /// PublicTeamMemberVendorStudentMinimal
    /// </summary>
    public class TeamMemberVendorStudentMinimal
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
        public VendorUserMinimal User { get; set; }
    }
}
