using System.Text.Json.Serialization;
using JetBrains.Annotations;

namespace JAG.Learnster.APIClient.Models.Requests.Student
{
    /// <summary>
    /// Active or deactivate user request
    /// </summary>
    [UsedImplicitly(ImplicitUseTargetFlags.Members)]
    internal class ActivateStatusRequest
    {
        public ActivateStatusRequest(bool isActive)
        {
            Active = isActive;
        }
        
        /// <summary>
        /// Active status
        /// </summary>
        [JsonPropertyName("active")]
        public bool Active { get; }
    }
}