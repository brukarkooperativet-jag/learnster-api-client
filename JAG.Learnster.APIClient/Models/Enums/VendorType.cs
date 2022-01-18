using System.Text.Json.Serialization;

namespace JAG.Learnster.APIClient.Models.Enums
{
    /// <summary>
    /// Defines Type
    /// </summary>
    public enum VendorType
    {
        /// <summary>
        /// Enum Default for value: default
        /// </summary>
        [JsonPropertyName("default")]
        Default = 1,
            
        /// <summary>
        /// Enum Inline for value: inline
        /// </summary>
        [JsonPropertyName("inline")]
        Inline = 2,
            
        /// <summary>
        /// Enum Regular for value: regular
        /// </summary>
        [JsonPropertyName("regular")]
        Regular = 3
    }
}