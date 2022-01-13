using System.Text.Json.Serialization;
using JAG.Learnster.APIClient.Models.Enums;

namespace JAG.Learnster.APIClient.Models.ApiContracts
{
    /// <summary>
    /// VendorRolesRoleSerializer
    /// </summary>
    public class VendorRolesRoleSerializer
    {
        /// <summary>
        /// Gets or Sets Type
        /// </summary>
        [JsonPropertyName("type")]
        public VendorTypeEnum? Type { get; set; }

        /// <summary>
        /// Gets or Sets Id
        /// </summary>
        [JsonPropertyName("id")]
        public Guid? Id { get; set; }

        /// <summary>
        /// Gets or Sets Name
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; }


        /// <summary>
        /// Gets or Sets Rank
        /// </summary>
        [JsonPropertyName("rank")]
        public int? Rank { get; set; }
    }
}
