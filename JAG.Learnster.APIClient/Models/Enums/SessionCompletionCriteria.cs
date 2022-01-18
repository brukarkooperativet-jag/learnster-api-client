using System.Text.Json.Serialization;

namespace JAG.Learnster.APIClient.Models.Enums
{
    /// <summary>
    /// Defines CompletionCriteria
    /// </summary>
    public enum SessionCompletionCriteria
    {
        /// <summary>
        /// Enum Dynamic for value: dynamic
        /// </summary>
        [JsonPropertyName("dynamic")]
        Dynamic = 1,
            
        /// <summary>
        /// Enum Static for value: static
        /// </summary>
        [JsonPropertyName("static")]
        Static = 2,
            
        /// <summary>
        /// Enum Manual for value: manual
        /// </summary>
        [JsonPropertyName("manual")]
        Manual = 3,
            
        /// <summary>
        /// Enum Off for value: off
        /// </summary>
        [JsonPropertyName("off")]
        Off = 4
    }
}