using System;
using System.ComponentModel.DataAnnotations;
using JetBrains.Annotations;

namespace JAG.Learnster.APIClient.Options
{
	/// <summary>
	/// Setting of learnster client
	/// </summary>
	[UsedImplicitly(ImplicitUseTargetFlags.Members)]
	public class LearnsterOptions
	{
		/// <summary>
		/// Name of setting section
		/// </summary>
		public const string SectionName = "Learnster";

		/// <summary>
		/// Url to learnster
		/// </summary>
		[Required]
		public Uri Url { get; set; }

		/// <summary>
		/// Vendor Id
		/// </summary>
		[Required]
		public Guid VendorId { get; set; }

		/// <summary>
		/// Vendor Id
		/// </summary>
		[Required]
		public string VendorName { get; set; }
		
		/// <summary>
		/// Client Id
		/// </summary>
		[Required]
		public Guid ClientId { get; set; }

		/// <summary>
		/// Client secret
		/// </summary>
		[Required]
		public string ClientSecret { get; set; }

		/// <summary>
		/// Grant type
		/// </summary>
		[Required]
		public string GrantType { get; set; }

		/// <summary>
		/// Url to API v1
		/// </summary>
		public Uri ApiV1Url => _apiV1Url ??= new Uri(Url, "api/public/v1/");
		private Uri _apiV1Url;
	}
}