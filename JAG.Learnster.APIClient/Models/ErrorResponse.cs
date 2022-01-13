using System.Text.Json.Serialization;

namespace JAG.Learnster.APIClient.Models
{
	internal class ErrorResponse
	{
		[JsonPropertyName("error")]
		public string Error { get; set; }
	}
}