using JAG.Learnster.APIClient.Interfaces;

namespace JAG.Learnster.APIClient.Clients
{
	public abstract class BaseAuthorizedClient
	{
		private readonly IAuthClient _authClient;

		protected BaseAuthorizedClient(IAuthClient authClient)
		{
			_authClient = authClient;
		}

		protected Task<HttpClient> AuthorizedClient
			=> _authClient.CreateAuthorizedClient();
	}
}