using System.Text.Json.Serialization;

namespace JAG.Learnster.APIClient.Models.ApiContracts
{
    /// <summary>
    /// PublicVendorStudentListExport
    /// </summary>
    public class VendorStudentListExport
    {
        /// <summary>
        /// Gets or Sets Id
        /// </summary>
        [JsonPropertyName("id")]
        public Guid? Id { get; set; }

        /// <summary>
        /// Gets or Sets Avatar
        /// </summary>
        [JsonPropertyName("avatar")]
        public string Avatar { get; set; }

        /// <summary>
        /// Gets or Sets FirstName
        /// </summary>
        [JsonPropertyName("first_name")]
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or Sets LastName
        /// </summary>
        [JsonPropertyName("last_name")]
        public string LastName { get; set; }

        /// <summary>
        /// Gets or Sets Emails
        /// </summary>
        [JsonPropertyName("emails")]
        public List<EmailShort> Emails { get; set; }

        /// <summary>
        /// Gets or Sets About
        /// </summary>
        [JsonPropertyName("about")]
        public string About { get; set; }

        /// <summary>
        /// Gets or Sets PersonalId
        /// </summary>
        [JsonPropertyName("personal_id")]
        public string PersonalId { get; set; }

        /// <summary>
        /// Gets or Sets CompanyLink
        /// </summary>
        [JsonPropertyName("company_link")]
        public CompanyShort CompanyLink { get; set; }

        /// <summary>
        /// Gets or Sets TitleLink
        /// </summary>
        [JsonPropertyName("title_link")]
        public TitleShort TitleLink { get; set; }

        /// <summary>
        /// Gets or Sets OfficeLink
        /// </summary>
        [JsonPropertyName("office_link")]
        public OfficeShort OfficeLink { get; set; }

        /// <summary>
        /// Gets or Sets Address
        /// </summary>
        [JsonPropertyName("address")]
        public AddressShort Address { get; set; }

        /// <summary>
        /// Gets or Sets PhoneNumber
        /// </summary>
        [JsonPropertyName("phone_number")]
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Gets or Sets LastSeen
        /// </summary>
        [JsonPropertyName("last_seen")]
        public DateTime? LastSeen { get; set; }

        /// <summary>
        /// Gets or Sets SsoCredentials
        /// </summary>
        [JsonPropertyName("sso_credentials")]
        public List<SsoCredentialsShort> SsoCredentials { get; set; }

        /// <summary>
        /// Gets or Sets CreatedDate
        /// </summary>
        [JsonPropertyName("created_date")]
        public DateTime? CreatedDate { get; set; }

        /// <summary>
        /// Gets or Sets Active
        /// </summary>
        [JsonPropertyName("active")]
        public bool? Active { get; set; }

        /// <summary>
        /// Gets or Sets Teams
        /// </summary>
        [JsonPropertyName("teams")]
        public List<TeamOfStudent> Teams { get; set; }

        /// <summary>
        /// Gets or Sets Tags
        /// </summary>
        [JsonPropertyName("tags")]
        public List<TagOfStudent> Tags { get; set; }

        /// <summary>
        /// Gets or Sets Sessions
        /// </summary>
        [JsonPropertyName("sessions")]
        public List<SessionOfStudent> Sessions { get; set; }

        /// <summary>
        /// Gets or Sets SessionsHistory
        /// </summary>
        [JsonPropertyName("sessions_history")]
        public List<SessionHistoryOfStudent> SessionsHistory { get; set; }

        /// <summary>
        /// Gets or Sets CustomAttributes
        /// </summary>
        [JsonPropertyName("custom_attributes")]
        public List<CustomAttributeOfStudent> CustomAttributes { get; set; }
    }
}
