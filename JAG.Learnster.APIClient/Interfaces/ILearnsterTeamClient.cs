using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using JAG.Learnster.APIClient.Models;
using JAG.Learnster.APIClient.Models.ApiContracts;
using JAG.Learnster.APIClient.Models.Requests.Team;

namespace JAG.Learnster.APIClient.Interfaces
{
    public interface ILearnsterTeamClient
    {
        /// <summary>
        /// Get all teams from learnster
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        Task<IReadOnlyCollection<Team>> GetAll();

        /// <summary>
        /// Get list of teams
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        Task<ResponseList<Team>> Get(int page, int count);

        /// <summary>
        /// Get team from learnster by Guid
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        Task<Team> GetTeam(Guid teamId);

        /// <summary>
        /// Search teams from learnster by Name
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        Task<IReadOnlyCollection<Team>> SearchTeamByName(string name);

        /// <summary>
        /// Get team by name
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        Task<Team> GetTeamByName(string name);

        /// <summary>
        /// Create new team
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        Task<Team> CreateTeam(CreateTeamRequest createTeamRequest);

        /// <summary>
        /// Delete team
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        Task DeleteTeam(Guid teamId);

        /// <summary>
        /// Add student to a team
        /// </summary>
        /// <param name="teamId">Team Id</param>
        /// <param name="studentId">Student Id</param>
        /// <param name="isManager">Is Admin</param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        Task<AddTeamMemberResult> AddMember(Guid teamId,
                                            Guid studentId,
                                            bool isManager = false);

        /// <summary>
        /// Remove student from a team
        /// </summary>
        /// <param name="teamId">Team Id</param>
        /// <param name="studentId">Student Id</param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        Task<RemoveTeamMemberResult> RemoveMember(Guid teamId,
                                                  Guid studentId);

        /// <summary>
        /// Get all members for the team
        /// </summary>
        /// <param name="teamId"></param>
        /// <returns></returns>
        Task<IReadOnlyCollection<VendorStudent>> GetMembers(Guid teamId);

        /// <summary>
        /// Get all managers for the team
        /// </summary>
        /// <param name="teamId"></param>
        /// <returns></returns>
        Task<IReadOnlyCollection<VendorStudent>> GetManagers(Guid teamId);

        /// <summary>
        /// Remove few member from the team
        /// </summary>
        /// <param name="teamId"></param>
        /// <param name="studentIds"></param>
        /// <returns></returns>
        Task RemoveMembers(Guid teamId, IReadOnlyCollection<Guid> studentIds);

        /// <summary>
        /// Remove few managers from the team
        /// </summary>
        /// <param name="teamId"></param>
        /// <param name="managerIds"></param>
        /// <returns></returns>
        Task RemoveManagers(Guid teamId, IReadOnlyCollection<Guid> managerIds);

        /// <summary>
        /// Get team list for the student
        /// </summary>
        /// <param name="studentId"></param>
        /// <returns></returns>
        Task<IReadOnlyCollection<TeamMinimal>> GetTeamsByStudent(Guid studentId);
    }
}