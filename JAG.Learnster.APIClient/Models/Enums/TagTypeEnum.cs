using System.Text.Json.Serialization;

namespace JAG.Learnster.APIClient.Models.Enums
{
    /// <summary>
    /// Defines Type
    /// </summary>
    public enum TagTypeEnum
    {
        /// <summary>
        /// Enum Course for value: course
        /// </summary>
        [JsonPropertyName("course")]
        Course = 1
    }
}