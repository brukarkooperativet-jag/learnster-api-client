using System.Text.Json.Serialization;

namespace JAG.Learnster.APIClient.Models.Enums
{
    /// <summary>
    /// Defines ManualApproval
    /// </summary>
    public enum ManualApprovalEnum
    {
        /// <summary>
        /// Enum Empty for value: empty
        /// </summary>
        [JsonPropertyName("empty")]
        Empty = 1,
            
        /// <summary>
        /// Enum Approved for value: approved
        /// </summary>
        [JsonPropertyName("approved")]
        Approved = 2,
            
        /// <summary>
        /// Enum Rejected for value: rejected
        /// </summary>
        [JsonPropertyName("rejected")]
        Rejected = 3
    }
}