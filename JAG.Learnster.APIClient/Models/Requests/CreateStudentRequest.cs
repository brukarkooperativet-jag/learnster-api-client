using System.Text.Json.Serialization;

namespace JAG.Learnster.APIClient.Models.Requests
{
    /// <summary>
    /// Create student api request
    /// </summary>
    public class CreateStudentRequest
    {
        /// <summary>
        /// First name
        /// </summary>
        [JsonPropertyName("first_name")]
        public string FirstName { get; set; }

        /// <summary>
        /// Last name
        /// </summary>
        [JsonPropertyName("last_name")]
        public string LastName { get; set; }

        /// <summary>
        /// Email
        /// </summary>
        [JsonPropertyName("email")]
        public string Email { get; set; }
    }
}