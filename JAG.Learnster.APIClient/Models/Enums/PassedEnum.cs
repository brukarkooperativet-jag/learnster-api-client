using System.Text.Json.Serialization;

namespace JAG.Learnster.APIClient.Models.Enums
{
    /// <summary>
    /// Defines Passed
    /// </summary>
    public enum PassedEnum
    {
        /// <summary>
        /// Enum Notexist for value: not_exist
        /// </summary>
        [JsonPropertyName("not_exist")]
        NotExist = 1,
            
        /// <summary>
        /// Enum Ongoing for value: ongoing
        /// </summary>
        [JsonPropertyName("ongoing")]
        Ongoing = 2,
            
        /// <summary>
        /// Enum Failed for value: failed
        /// </summary>
        [JsonPropertyName("failed")]
        Failed = 3,
            
        /// <summary>
        /// Enum Success for value: success
        /// </summary>
        [JsonPropertyName("success")]
        Success = 4,
            
        /// <summary>
        /// Enum Pending for value: pending
        /// </summary>
        [JsonPropertyName("pending")]
        Pending = 5
    }
}