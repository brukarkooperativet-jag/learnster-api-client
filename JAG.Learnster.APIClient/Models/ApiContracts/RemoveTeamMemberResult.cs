using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using JetBrains.Annotations;

namespace JAG.Learnster.APIClient.Models.ApiContracts
{
    /// <summary>
    /// PublicRemoveTeamMember
    /// </summary>
    [UsedImplicitly(ImplicitUseTargetFlags.Members)]
    public class RemoveTeamMemberResult
    {
        /// <summary>
        /// Gets or Sets Id
        /// </summary>
        [JsonPropertyName("id")]
        public Guid Id { get; set; }

        /*
         TODO: [Bug] We have the field in th contract but they are empty from the learnster API
        /// <summary>
        /// Gets or Sets VendorStudentId
        /// </summary>
        [JsonPropertyName("vendor_student_id")]
        public Guid VendorStudentId { get; set; }
        */
        
        /// <summary>
        /// Gets or Sets Members
        /// </summary>
        [JsonPropertyName("members")]
        public List<VendorStudent> Members { get; set; }

        /// <summary>
        /// Gets or Sets Managers
        /// </summary>
        [JsonPropertyName("managers")]
        public List<VendorStudent> Managers { get; set; }
    }
}