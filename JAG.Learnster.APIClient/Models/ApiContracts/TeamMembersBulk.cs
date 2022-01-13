using System.Text.Json.Serialization;

namespace JAG.Learnster.APIClient.Models.ApiContracts
{
    /// <summary>
    /// PublicTeamMembersBulk
    /// </summary>
    public class TeamMembersBulk
    {
        /// <summary>
        /// Gets or Sets UpdateList
        /// </summary>
        [JsonPropertyName("update_list")]
        public List<Guid?> UpdateList { get; set; }

        /// <summary>
        /// Gets or Sets RemoveList
        /// </summary>
        [JsonPropertyName("remove_list")]
        public List<Guid?> RemoveList { get; set; }
    }
}
