using System.Text.Json.Serialization;

namespace JAG.Learnster.APIClient.Models.ApiContracts
{
    /// <summary>
    /// PublicSessionSettings
    /// </summary>
    public class SessionSettings
    {
        /// <summary>
        /// Gets or Sets AvatarOverlayColor
        /// </summary>
        [JsonPropertyName("avatar_overlay_color")]
        public string AvatarOverlayColor { get; set; }

        /// <summary>
        /// Gets or Sets AvatarTextColor
        /// </summary>
        [JsonPropertyName("avatar_text_color")]
        public string AvatarTextColor { get; set; }

        /// <summary>
        /// Gets or Sets AvatarOverlayOpacity
        /// </summary>
        [JsonPropertyName("avatar_overlay_opacity")]
        public int? AvatarOverlayOpacity { get; set; }

        /// <summary>
        /// Gets or Sets AvatarReposition
        /// </summary>
        [JsonPropertyName("avatar_reposition")]
        public List<int?> AvatarReposition { get; set; }
    }
}
