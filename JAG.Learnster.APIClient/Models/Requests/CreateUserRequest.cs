using System.Text.Json.Serialization;

namespace JAG.Learnster.APIClient.Models.Requests
{
    /// <summary>
    /// Create user request
    /// </summary>
    public class CreateUserRequest
    {
        /// <summary>
        /// New user information
        /// </summary>
        [JsonPropertyName("user")]
        public CreateStudentRequest User { get; set; }
    }
}