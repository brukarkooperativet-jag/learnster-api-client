using System;

namespace JAG.Learnster.APIClient.Options
{
	public class LearnsterOptions
	{
		public const string SECTION_NAME = "Learnster";

		public Uri ApiUrl { get; set; }

		public Guid VendorId { get; set; }

		public Guid ClientId { get; set; }
		
		public string ClientSecret { get; set; }

		public string GrantType { get; set; }
	}
}