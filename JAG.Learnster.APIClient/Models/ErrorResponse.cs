using System.Text.Json;
using System.Text.Json.Serialization;

namespace JAG.Learnster.APIClient.Models
{
	/// <summary>
	/// Learnster Api error model
	/// </summary>
	internal class ErrorResponse
	{
		[JsonPropertyName("error")]
		public string Error { get; set; }
		
		[JsonPropertyName("code")]
		public string Code { get; set; }
		
		[JsonPropertyName("detail")]
		public JsonElement? Details { get; set; }

		public override string ToString()
		{
			var errorText = $"Learnster error code: {Code}.";
			
			if (!string.IsNullOrWhiteSpace(Error))
				errorText += $" Error: {Error}.";
			
			if (Details != null)
				errorText += $" Details: {Details}.";

			return errorText;
		}
	}
}