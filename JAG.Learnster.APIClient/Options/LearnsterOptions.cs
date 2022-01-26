using System;
using System.ComponentModel.DataAnnotations;

namespace JAG.Learnster.APIClient.Options
{
	/// <summary>
	/// Setting of learnster client
	/// </summary>
	public class LearnsterOptions
	{
		/// <summary>
		/// Name of setting section
		/// </summary>
		public const string SECTION_NAME = "Learnster";

		/// <summary>
		/// Url to learnster api
		/// </summary>
		[Required]
		public Uri ApiUrl { get; set; }

		/// <summary>
		/// Vendor Id
		/// </summary>
		[Required]
		public Guid VendorId { get; set; }

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
	}
}