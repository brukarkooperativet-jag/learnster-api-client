using System.Runtime.Serialization;

namespace JAG.Learnster.APIClient.Models.Enums
{
    /// <summary>
    /// Defines FileType
    /// </summary>
    public enum FileType
    {
        /// <summary>
        /// Enum ImageBitmap for value: image-bitmap
        /// </summary>
        [EnumMember(Value = "image-bitmap")]
        ImageBitmap = 1,
            
        /// <summary>
        /// Enum ImageVector for value: image-vector
        /// </summary>
        [EnumMember(Value = "image-vector")]
        ImageVector = 2,
            
        /// <summary>
        /// Enum Audio for value: audio
        /// </summary>
        [EnumMember(Value = "audio")]
        Audio = 3,
            
        /// <summary>
        /// Enum Video for value: video
        /// </summary>
        [EnumMember(Value = "video")]
        Video = 4,
            
        /// <summary>
        /// Enum Scorm for value: scorm
        /// </summary>
        [EnumMember(Value = "scorm")]
        Scorm = 5,
            
        /// <summary>
        /// Enum Document for value: document
        /// </summary>
        [EnumMember(Value = "document")]
        Document = 6
    }
}