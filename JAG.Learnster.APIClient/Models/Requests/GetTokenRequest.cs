using System;
using System.Text.Json.Serialization;

namespace JAG.Learnster.APIClient.Models.Requests
{
	internal class GetTokenRequest
	{
		[JsonPropertyName("client_id")]
		public Guid ClientId { get; set; }
		
		[JsonPropertyName("client_secret")]
		public string ClientSecret { get; set; }
		
		[JsonPropertyName("grant_type")]
		public string GrantType { get; set; }
	}
}