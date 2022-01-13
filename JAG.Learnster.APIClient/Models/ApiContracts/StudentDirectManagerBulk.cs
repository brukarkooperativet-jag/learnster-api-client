using System.Text.Json.Serialization;

namespace JAG.Learnster.APIClient.Models.ApiContracts
{
    /// <summary>
    /// PublicStudentDirectManagerBulk
    /// </summary>
    public class StudentDirectManagerBulk
    {
        /// <summary>
        /// Gets or Sets UpdateList
        /// </summary>
        [JsonPropertyName("update_list")]
        public List<DirectManagerBulkNamedIdentity> UpdateList { get; set; }

        /// <summary>
        /// Gets or Sets RemoveList
        /// </summary>
        [JsonPropertyName("remove_list")]
        public List<DirectManagerBulkUnnamedIdentity> RemoveList { get; set; }
    }
}
