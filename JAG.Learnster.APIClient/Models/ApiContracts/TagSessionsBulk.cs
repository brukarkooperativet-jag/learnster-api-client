using System.Text.Json.Serialization;

namespace JAG.Learnster.APIClient.Models.ApiContracts
{
    /// <summary>
    /// PublicTagSessionsBulk
    /// </summary>
    public class TagSessionsBulk
    {
        /// <summary>
        /// Gets or Sets UpdateList
        /// </summary>
        [JsonPropertyName("update_list")]
        public List<Guid?> UpdateList { get; set; }

        /// <summary>
        /// Gets or Sets RemoveList
        /// </summary>
        [JsonPropertyName("remove_list")]
        public List<Guid?> RemoveList { get; set; }

        /// <summary>
        /// Gets or Sets RemoveCourseParticipants
        /// </summary>
        [JsonPropertyName("remove_course_participants")]
        public bool? RemoveCourseParticipants { get; set; }
    }

}
