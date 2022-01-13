using System.Text.Json.Serialization;
using JAG.Learnster.APIClient.Models.Enums;

namespace JAG.Learnster.APIClient.Models.ApiContracts
{
    /// <summary>
    /// PublicImageAssetAttachment
    /// </summary>
    public class ImageAssetAttachment
    {
        /// <summary>
        /// Gets or Sets FileType
        /// </summary>
        [JsonPropertyName("file_type")]
        public FileTypeEnum? FileType { get; set; }
        
        /// <summary>
        /// Gets or Sets Url
        /// </summary>
        [JsonPropertyName("url")]
        public string Url { get; set; }

        /// <summary>
        /// Gets or Sets Id
        /// </summary>
        [JsonPropertyName("id")]
        public Guid? Id { get; set; }

        /// <summary>
        /// Gets or Sets Remove
        /// </summary>
        [JsonPropertyName("remove")]
        public bool? Remove { get; set; }

        /// <summary>
        /// Gets or Sets PostData
        /// </summary>
        [JsonPropertyName("post_data")]
        public PresignedPost PostData { get; set; }

        /// <summary>
        /// Gets or Sets FileName
        /// </summary>
        [JsonPropertyName("file_name")]
        public string FileName { get; set; }

        /// <summary>
        /// Gets or Sets MetaAssetId
        /// </summary>
        [JsonPropertyName("meta_asset_id")]
        public Guid? MetaAssetId { get; set; }

        /// <summary>
        /// Gets or Sets FileStatus
        /// </summary>
        [JsonPropertyName("file_status")]
        public string FileStatus { get; set; }

        /// <summary>
        /// Gets or Sets Size
        /// </summary>
        [JsonPropertyName("size")]
        public int? Size { get; set; }

        /// <summary>
        /// Gets or Sets Mimetype
        /// </summary>
        [JsonPropertyName("mimetype")]
        public string Mimetype { get; set; }

        /// <summary>
        /// Gets or Sets AdditionalData
        /// </summary>
        [JsonPropertyName("additional_data")]
        public Object AdditionalData { get; set; }
    }
}
