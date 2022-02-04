using System;
using System.Collections.Generic;
using System.Threading.Tasks;
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

        // /// <summary>
        // /// Add student to a team by team name
        // /// </summary>
        // /// <param name="teamName"></param>
        // /// <param name="studentId">Student Id</param>
        // /// <param name="isAdmin">Is Admin</param>
        // /// <returns></returns>
        // /// <exception cref="Exception"></exception>
        // Task<AddTeamMemberResult> AddMember(string teamName,
        //                                     Guid studentId,
        //                                     bool isAdmin = false);

        /// <summary>
        /// Remove student from a team
        /// </summary>
        /// <param name="teamId">Team Id</param>
        /// <param name="studentId">Student Id</param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        Task<RemoveTeamMemberResult> RemoveMember(Guid teamId,
                                                  Guid studentId);

        // /// <summary>
        // /// Remove student from a team by team name
        // /// </summary>
        // /// <param name="teamName"></param>
        // /// <param name="studentId">Student Id</param>
        // /// <returns></returns>
        // /// <exception cref="Exception"></exception>
        // Task<AddTeamMemberResult> RemoveMember(string teamName,
        //                                        Guid studentId);
    }
}