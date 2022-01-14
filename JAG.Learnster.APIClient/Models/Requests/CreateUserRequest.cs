using System.Text.Json.Serialization;

namespace JAG.Learnster.APIClient.Models.Requests
{
    public class CreateUserRequest
    {
        [JsonPropertyName("user")]
        public CreateStudentRequest User { get; set; }
    }
}