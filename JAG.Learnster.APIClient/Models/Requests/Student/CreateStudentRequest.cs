using System.Collections.Generic;
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

        /// <summary>
        /// Gets or Sets SsoCredentials
        /// </summary>
        [JsonPropertyName("sso_credentials")]
        public List<CreateSsoCredentialsRequest> SsoCredentials { get; set; }

        /// <summary>
        /// Controlled by integration
        /// </summary>
        [JsonPropertyName("controlled_by_integration")]
        public bool ControlledByIntegration { get; set; } = true;
    }
}