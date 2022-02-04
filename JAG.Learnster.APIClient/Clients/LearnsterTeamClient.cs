using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Threading.Tasks;
using JAG.Learnster.APIClient.Extensions;
using JAG.Learnster.APIClient.Interfaces;
using JAG.Learnster.APIClient.Models;
using JAG.Learnster.APIClient.Models.ApiContracts;
using JAG.Learnster.APIClient.Models.Requests.Team;
using JAG.Learnster.APIClient.Options;
using JetBrains.Annotations;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace JAG.Learnster.APIClient.Clients
{
    /// <inheritdoc cref="ILearnsterTeamClient" />
    public class LearnsterTeamClient : BaseClient, ILearnsterTeamClient
    {
        private readonly LearnsterOptions _learnsterOptions;
        private readonly ILogger<LearnsterTeamClient> _logger;
        private readonly ILearnsterHttpClientFactory _httpClientFactory;

        public LearnsterTeamClient(IOptions<LearnsterOptions> learnsterOptions,
                                   ILogger<LearnsterTeamClient> logger,
                                   ILearnsterHttpClientFactory httpClientFactory)
            : base(logger)
        {
            _learnsterOptions = learnsterOptions.Value;
            _logger = logger;
            _httpClientFactory = httpClientFactory;
        }

        /// <inheritdoc/>
        public async Task<IReadOnlyCollection<Team>> GetAll()
        {
            using (var client = await _httpClientFactory.CreateAuthorizedClient())
            {
#if DEBUG
                _logger.LogDebug("Getting team list from Learnster");
#endif

                var response = await client.GetAsync($"vendor/{_learnsterOptions.VendorId}/teams/");

                if (response.IsSuccessStatusCode)
                    return await response
                        .DeserializeContent<ResponseList<Team>>()
                        .ContinueWith(x => x.Result.Results);

                throw await ThrowGetException(response, "Team list");
            }
        }
        
        /// <inheritdoc/>
        public async Task<Team> GetTeam(Guid teamId)
        {
            using (var client = await _httpClientFactory.CreateAuthorizedClient())
            {
#if DEBUG
                _logger.LogDebug("Getting team list from Learnster");
#endif

                var response = await client.GetAsync($"vendor/{_learnsterOptions.VendorId}/teams/{teamId}/");

                if (response.IsSuccessStatusCode)
                    return await response.DeserializeContent<Team>();

                throw await ThrowGetException(response, "Team list");
            }
        }
        
        /// <inheritdoc/>
        public async Task<IReadOnlyCollection<Team>> SearchTeamByName(string name)
        {
            using (var client = await _httpClientFactory.CreateAuthorizedClient())
            {
#if DEBUG
                _logger.LogDebug("Getting team list from Learnster");
#endif

                var url = $"vendor/{_learnsterOptions.VendorId}/teams/?name={name}";
                var response = await client.GetAsync(url);

                if (response.IsSuccessStatusCode)
                    return await response
                        .DeserializeContent<ResponseList<Team>>()
                        .ContinueWith(x => x.Result.Results);

                throw await ThrowGetException(response, "Team list");
            }
        }
        
        /// <inheritdoc/>
        [ItemCanBeNull]
        public Task<Team> GetTeamByName(string name)
        {
            return SearchTeamByName(name).ContinueWith(x => x.Result.FirstOrDefault());
        }
        
        /// <inheritdoc/>
        public async Task<Team> CreateTeam(CreateTeamRequest createTeamRequest)
        {
            using (var client = await _httpClientFactory.CreateAuthorizedClient())
            {
#if DEBUG
                _logger.LogDebug("Creating Learnster team");
#endif

                var url = $"vendor/{_learnsterOptions.VendorId}/teams/";
                var response = await client.PostAsJsonAsync(url, createTeamRequest);

                if (response.IsSuccessStatusCode)
                    return await response.DeserializeContent<Team>();

                throw await CreatePostException(response, "Create team");
            }
        }

        /// <inheritdoc/>
        public async Task DeleteTeam(Guid teamId)
        {
            using (var client = await _httpClientFactory.CreateAuthorizedClient())
            {
#if DEBUG
                _logger.LogDebug("Deleting learnster team");
#endif
                var url = $"vendor/{_learnsterOptions.VendorId}/teams/{teamId}/";
                var response = await client.DeleteAsync(url);

                if (response.IsSuccessStatusCode)
                    return;

                throw await CreateDeleteException(response, "Team");
            }
        }

        /// <inheritdoc/>
        public async Task<AddTeamMemberResult> AddMember(Guid teamId,
                                                         Guid studentId,
                                                         bool isManager = false)
        {
            using (var client = await _httpClientFactory.CreateAuthorizedClient())
            {
#if DEBUG
                _logger.LogDebug("Adding student to a team");
#endif
                var addMemberRequest = new AddTeamMemberRequest()
                {
                    StudentId = studentId,
                    IsManager = isManager
                };

                var url = $"vendor/{_learnsterOptions.VendorId}/teams/{teamId}/members/add-member/";
                var response = await client.PutAsJsonAsync(url, addMemberRequest);

                if (response.IsSuccessStatusCode)
                    return await response.DeserializeContent<AddTeamMemberResult>();

                throw await CreatePutException(response, "Create team");
            }
        }

        // /// <inheritdoc/>
        // public async Task<AddTeamMemberResult> AddMember(string teamName,
        //                                                  Guid studentId,
        //                                                  bool isManager = false)
        // {
        //     var team = await GetTeamByName(teamName);
        //
        //     if (team == null)
        //     {
        //         _logger.LogError("Team {TeamName} cannot be found", teamName);
        //         throw new NotFoundLearnsterException($"Team {teamName} cannot be found");
        //     }
        //
        //     return await AddMember(team.Id, studentId, isManager);
        // }
        
        
        /// <inheritdoc/>
        public async Task<RemoveTeamMemberResult> RemoveMember(Guid teamId,
                                                            Guid studentId)
        {
            using (var client = await _httpClientFactory.CreateAuthorizedClient())
            {
#if DEBUG
                _logger.LogDebug("Removing student from a team");
#endif
                var addMemberRequest = new AddTeamMemberRequest()
                {
                    StudentId = studentId,
                };

                var url = $"vendor/{_learnsterOptions.VendorId}/teams/{teamId}/members/remove-member/";
                var response = await client.PutAsJsonAsync(url, addMemberRequest);

                if (response.IsSuccessStatusCode)
                    return await response.DeserializeContent<RemoveTeamMemberResult>();

                throw await CreatePostException(response, "Create team");
            }
        }

        // /// <inheritdoc/>
        // public async Task<AddTeamMemberResult> RemoveMember(string teamName,
        //                                                     Guid studentId)
        // {
        //     var team = await GetTeamByName(teamName);
        //
        //     if (team == null)
        //     {
        //         _logger.LogError("Team {TeamName} cannot be found", teamName);
        //         throw new NotFoundLearnsterException($"Team {teamName} cannot be found");
        //     }
        //
        //     return await RemoveMember(team.Id, studentId);
        // }
    }
}