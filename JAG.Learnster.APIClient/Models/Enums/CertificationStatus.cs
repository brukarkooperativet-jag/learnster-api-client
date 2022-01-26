using System.Runtime.Serialization;

namespace JAG.Learnster.APIClient.Models.Enums
{
    /// <summary>
    /// Defines Status
    /// </summary>
    public enum CertificationStatus
    {
        /// <summary>
        /// Enum DISABLED for value: DISABLED
        /// </summary>
        [EnumMember(Value = "DISABLED")]
        Disabled = 1,
            
        /// <summary>
        /// Enum CERTIFIED for value: CERTIFIED
        /// </summary>
        [EnumMember(Value = "CERTIFIED")]
        Certified = 2,
            
        /// <summary>
        /// Enum RECERTIFICATION for value: RECERTIFICATION
        /// </summary>
        [EnumMember(Value = "RECERTIFICATION")]
        Recertification = 3,
            
        /// <summary>
        /// Enum EXPIRED for value: EXPIRED
        /// </summary>
        [EnumMember(Value = "EXPIRED")]
        Expired = 4,
            
        /// <summary>
        /// Enum NOTCERTIFIED for value: NOT_CERTIFIED
        /// </summary>
        [EnumMember(Value = "NOT_CERTIFIED")]
        NotCertified = 5
    }
}