using System.Text.Json.Serialization;

namespace JAG.Learnster.APIClient.Models.ApiContracts
{
	/// <summary>
	/// Auth token from API
	/// </summary>
	public class AuthToken
	{
		/// <summary>
		/// Access token
		/// </summary>
		[JsonPropertyName("access_token")]
		public string AccessToken { get; set; }
		
		/// <summary>
		/// Expires in, seconds
		/// </summary>
		[JsonPropertyName("expires_in")]
		public int ExpiresIn { get; set; }

		/// <summary>
		/// Scope
		/// </summary>
		[JsonPropertyName("scope")]
		public string Scope { get; set; }

		/// <summary>
		/// Token type
		/// </summary>
		[JsonPropertyName("token_type")]
		public string TokenType { get; set; }
	}
}