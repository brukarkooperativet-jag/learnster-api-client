using System.Runtime.Serialization;

namespace JAG.Learnster.APIClient.Models.Enums
{
    /// <summary>
    /// Defines Format
    /// </summary>
    public enum SessionFormat
    {
        /// <summary>
        /// Enum Classroom for value: classroom
        /// </summary>
        [EnumMember(Value = "classroom")]
        Classroom = 1,
            
        /// <summary>
        /// Enum ELearning for value: e-learning
        /// </summary>
        [EnumMember(Value = "e-learning")]
        ELearning = 2,
            
        /// <summary>
        /// Enum Blended for value: blended
        /// </summary>
        [EnumMember(Value = "blended")]
        Blended1 = 3
    }
}