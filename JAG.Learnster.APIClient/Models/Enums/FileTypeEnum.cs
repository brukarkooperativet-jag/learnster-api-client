using System.Text.Json.Serialization;

namespace JAG.Learnster.APIClient.Models.Enums
{
    /// <summary>
    /// Defines FileType
    /// </summary>
    public enum FileTypeEnum
    {
        /// <summary>
        /// Enum ImageBitmap for value: image-bitmap
        /// </summary>
        [JsonPropertyName("image-bitmap")]
        ImageBitmap = 1,
            
        /// <summary>
        /// Enum ImageVector for value: image-vector
        /// </summary>
        [JsonPropertyName("image-vector")]
        ImageVector = 2,
            
        /// <summary>
        /// Enum Audio for value: audio
        /// </summary>
        [JsonPropertyName("audio")]
        Audio = 3,
            
        /// <summary>
        /// Enum Video for value: video
        /// </summary>
        [JsonPropertyName("video")]
        Video = 4,
            
        /// <summary>
        /// Enum Scorm for value: scorm
        /// </summary>
        [JsonPropertyName("scorm")]
        Scorm = 5,
            
        /// <summary>
        /// Enum Document for value: document
        /// </summary>
        [JsonPropertyName("document")]
        Document = 6
    }
}