using System.Text.Json.Serialization;

namespace JAG.Learnster.APIClient.Models.ApiContracts
{
    /// <summary>
    /// PublicCustomAttributeOfStudent
    /// </summary>
    public class CustomAttributeOfStudent
    {
        /// <summary>
        /// Gets or Sets Id
        /// </summary>
        [JsonPropertyName("id")]
        public Guid? Id { get; set; }

        /// <summary>
        /// Gets or Sets Value
        /// </summary>
        [JsonPropertyName("value")]
        public string Value { get; set; }

        /// <summary>
        /// Gets or Sets Annotation
        /// </summary>
        [JsonPropertyName("annotation")]
        public string Annotation { get; set; }

        /// <summary>
        /// Gets or Sets AttributeName
        /// </summary>
        [JsonPropertyName("attribute_name")]
        public string AttributeName { get; set; }

        /// <summary>
        /// Gets or Sets AttributeType
        /// </summary>
        [JsonPropertyName("attribute_type")]
        public string AttributeType { get; set; }
    }
}
