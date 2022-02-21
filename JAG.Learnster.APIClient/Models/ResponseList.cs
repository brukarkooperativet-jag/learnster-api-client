using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace JAG.Learnster.APIClient.Models
{
	/// <summary>
	/// List of result items
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public class ResponseList<T>
	{
		/// <summary>
		/// Count of items in the current bulk
		/// </summary>
		[JsonPropertyName("count")]
		public int Count { get; set; }

		/// <summary>
		/// Next bulk of results
		/// </summary>
		[JsonPropertyName("next")]
		public Uri Next { get; set; }

		/// <summary>
		/// Previous bulk of results
		/// </summary>
		[JsonPropertyName("previous")]
		public Uri Previous { get; set; }

		/// <summary>
		/// Collection of results
		/// </summary>
		[JsonPropertyName("results")]
		public IReadOnlyCollection<T> Results { get; set; }
	}
}