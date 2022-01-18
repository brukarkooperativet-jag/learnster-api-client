using System.Text.Json.Serialization;

namespace JAG.Learnster.APIClient.Models.Enums
{
    /// <summary>
    /// Defines Status
    /// </summary>
    public enum CertificationStatus
    {
        /// <summary>
        /// Enum DISABLED for value: DISABLED
        /// </summary>
        [JsonPropertyName("DISABLED")]
        Disabled = 1,
            
        /// <summary>
        /// Enum CERTIFIED for value: CERTIFIED
        /// </summary>
        [JsonPropertyName("CERTIFIED")]
        Certified = 2,
            
        /// <summary>
        /// Enum RECERTIFICATION for value: RECERTIFICATION
        /// </summary>
        [JsonPropertyName("RECERTIFICATION")]
        Recertification = 3,
            
        /// <summary>
        /// Enum EXPIRED for value: EXPIRED
        /// </summary>
        [JsonPropertyName("EXPIRED")]
        Expired = 4,
            
        /// <summary>
        /// Enum NOTCERTIFIED for value: NOT_CERTIFIED
        /// </summary>
        [JsonPropertyName("NOT_CERTIFIED")]
        NotCertified = 5
    }
}