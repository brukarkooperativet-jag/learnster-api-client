using System;
using System.Text.Json.Serialization;
using JetBrains.Annotations;

namespace JAG.Learnster.APIClient.Models.Requests.Student
{
    /// <summary>
    /// Update student request
    /// </summary>
    [UsedImplicitly(ImplicitUseTargetFlags.Members)]
    public class UpdateStudentRequest
    {
        /// <summary>
        /// Student Id
        /// </summary>
        [JsonIgnore]
        public Guid StudentId { get; set; } 
        
        /// <summary>
        /// New user information
        /// </summary>
        [JsonPropertyName("user")]
        public UpdateUserRequest User { get; set; }
    }
}