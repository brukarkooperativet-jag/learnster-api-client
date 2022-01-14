using System.Text.Json.Serialization;

namespace JAG.Learnster.APIClient.Models.Requests
{
    public class CreateStudentRequest
    {
        [JsonPropertyName("first_name")]
        public string FirstName { get; set; }

        [JsonPropertyName("last_name")]
        public string LastName { get; set; }

        [JsonPropertyName("email")]
        public string Email { get; set; }
    }
}