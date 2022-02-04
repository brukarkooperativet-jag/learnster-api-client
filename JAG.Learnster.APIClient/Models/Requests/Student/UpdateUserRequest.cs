using System.Text.Json.Serialization;
using JetBrains.Annotations;

namespace JAG.Learnster.APIClient.Models.Requests.Student
{
    /// <summary>
    /// Update user api request
    /// </summary>
    [UsedImplicitly(ImplicitUseTargetFlags.Members)]
    public class UpdateUserRequest
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