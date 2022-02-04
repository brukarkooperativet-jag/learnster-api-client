using System.Text.Json.Serialization;
using JetBrains.Annotations;

namespace JAG.Learnster.APIClient.Models.Requests.Student
{
    /// <summary>
    /// Create student request
    /// </summary>
    [UsedImplicitly(ImplicitUseTargetFlags.Members)]
    public class CreateStudentRequest
    {
        /// <summary>
        /// New user information
        /// </summary>
        [JsonPropertyName("user")]
        public CreateUserRequest User { get; set; }
    }
}