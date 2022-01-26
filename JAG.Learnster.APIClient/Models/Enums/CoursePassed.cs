using System.Runtime.Serialization;

namespace JAG.Learnster.APIClient.Models.Enums
{
    /// <summary>
    /// Defines Passed
    /// </summary>
    public enum CoursePassed
    {
        /// <summary>
        /// Enum Notexist for value: not_exist
        /// </summary>
        [EnumMember(Value = "not_exist")]
        NotExist = 1,
            
        /// <summary>
        /// Enum Ongoing for value: ongoing
        /// </summary>
        [EnumMember(Value = "ongoing")]
        Ongoing = 2,
            
        /// <summary>
        /// Enum Failed for value: failed
        /// </summary>
        [EnumMember(Value = "failed")]
        Failed = 3,
            
        /// <summary>
        /// Enum Success for value: success
        /// </summary>
        [EnumMember(Value = "success")]
        Success = 4,
            
        /// <summary>
        /// Enum Pending for value: pending
        /// </summary>
        [EnumMember(Value = "pending")]
        Pending = 5
    }
}