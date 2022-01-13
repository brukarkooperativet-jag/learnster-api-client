using System.Text.Json.Serialization;

namespace JAG.Learnster.APIClient.Models.ApiContracts
{
    /// <summary>
    /// PublicTagUser
    /// </summary>
    public class TagUser
    {
        /// <summary>
        /// Gets or Sets Id
        /// </summary>
        [JsonPropertyName("id")]
        public int? Id { get; set; }

        /// <summary>
        /// Gets or Sets Tag
        /// </summary>
        [JsonPropertyName("tag")]
        public Guid? Tag { get; set; }

        /// <summary>
        /// Gets or Sets Student
        /// </summary>
        [JsonPropertyName("student")]
        public VendorTagsStudentSerializer Student { get; set; }
    }
}
