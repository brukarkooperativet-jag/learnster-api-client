using System.Runtime.Serialization;

namespace JAG.Learnster.APIClient.Models.Enums
{
    /// <summary>
    /// Defines Type
    /// </summary>
    public enum VendorType
    {
        /// <summary>
        /// Enum Default for value: default
        /// </summary>
        [EnumMember(Value = "default")]
        Default = 1,
            
        /// <summary>
        /// Enum Inline for value: inline
        /// </summary>
        [EnumMember(Value = "inline")]
        Inline = 2,
            
        /// <summary>
        /// Enum Regular for value: regular
        /// </summary>
        [EnumMember(Value = "regular")]
        Regular = 3
    }
}