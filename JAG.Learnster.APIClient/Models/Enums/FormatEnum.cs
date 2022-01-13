using System.Text.Json.Serialization;

namespace JAG.Learnster.APIClient.Models.Enums
{
    /// <summary>
    /// Defines Format
    /// </summary>
    public enum FormatEnum
    {
        /// <summary>
        /// Enum Classroom for value: classroom
        /// </summary>
        [JsonPropertyName("classroom")]
        Classroom = 1,
            
        /// <summary>
        /// Enum ELearning for value: e-learning
        /// </summary>
        [JsonPropertyName("e-learning")]
        ELearning = 2,
            
        /// <summary>
        /// Enum Blended for value: blended
        /// </summary>
        [JsonPropertyName("blended")]
        Blended = 3
    }
}