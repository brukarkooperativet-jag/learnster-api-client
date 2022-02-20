namespace JAG.Learnster.APIClient.Constants
{
    /// <summary>
    /// Names of SSO provides
    /// </summary>
    // TODO: Convert to enum
    public static class SsoProviderName
    {
        public const string OpenIdConnect = "AzureOpenID";
        public const string Azure = "AzureAD";
        public const string Google = "GSuiteSAML";
        public const string Saml = "GeneralSAML";
    }
}