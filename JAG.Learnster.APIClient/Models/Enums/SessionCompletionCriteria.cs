using System.Runtime.Serialization;

namespace JAG.Learnster.APIClient.Models.Enums
{
    /// <summary>
    /// Defines CompletionCriteria
    /// </summary>
    public enum SessionCompletionCriteria
    {
        /// <summary>
        /// Enum Dynamic for value: dynamic
        /// </summary>
        [EnumMember(Value = "dynamic")]
        Dynamic = 1,
            
        /// <summary>
        /// Enum Static for value: static
        /// </summary>
        [EnumMember(Value = "static")]
        Static = 2,
            
        /// <summary>
        /// Enum Manual for value: manual
        /// </summary>
        [EnumMember(Value = "manual")]
        Manual = 3,
            
        /// <summary>
        /// Enum Off for value: off
        /// </summary>
        [EnumMember(Value = "off")]
        Off = 4
    }
}