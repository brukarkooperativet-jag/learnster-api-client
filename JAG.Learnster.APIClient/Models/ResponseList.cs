using System.Text.Json.Serialization;

namespace JAG.Learnster.APIClient.Models
{
	public class ResponseList<T>
	{
		[JsonPropertyName("count")]
		public int Count { get; set; }

		// TODO: Test uris
		public Uri Next { get; set; }
		public Uri Previous { get; set; }

		[JsonPropertyName("results")]
		public IReadOnlyCollection<T> Results { get; set; }
	}
}