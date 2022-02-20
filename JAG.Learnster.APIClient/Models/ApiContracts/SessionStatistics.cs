using System.Text.Json.Serialization;

namespace JAG.Learnster.APIClient.Models.ApiContracts
{
    /// <summary>
    /// PublicSessionStatistics
    /// </summary>
    public class SessionStatistics
    {
        /// <summary>
        /// Gets or Sets AvgProgress
        /// </summary>
        [JsonPropertyName("avg_progress")]
        public decimal? AvgProgress { get; set; }

        /// <summary>
        /// Gets or Sets StudentsTotal
        /// </summary>
        [JsonPropertyName("students_total")]
        public int? StudentsTotal { get; set; }

        /// <summary>
        /// Gets or Sets CommentsTotal
        /// </summary>
        [JsonPropertyName("comments_total")]
        public int? CommentsTotal { get; set; }
    }
}
