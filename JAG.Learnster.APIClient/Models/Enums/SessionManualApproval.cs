using System.Runtime.Serialization;

namespace JAG.Learnster.APIClient.Models.Enums
{
    /// <summary>
    /// Defines ManualApproval
    /// </summary>
    public enum SessionManualApproval
    {
        /// <summary>
        /// Enum Empty for value: empty
        /// </summary>
        [EnumMember(Value = "empty")]
        Empty = 1,
            
        /// <summary>
        /// Enum Approved for value: approved
        /// </summary>
        [EnumMember(Value = "approved")]
        Approved = 2,
            
        /// <summary>
        /// Enum Rejected for value: rejected
        /// </summary>
        [EnumMember(Value = "rejected")]
        Rejected = 3
    }
}