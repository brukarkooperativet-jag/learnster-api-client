using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using JAG.Learnster.APIClient.Models;
using JAG.Learnster.APIClient.Models.ApiContracts;

namespace JAG.Learnster.APIClient.Interfaces
{
    public interface ISessionsClient
    {
        /// <summary>
        /// Get all available sessions for student
        /// </summary>
        /// <param name="studentId"></param>
        /// <returns></returns>
        Task<ResponseList<PossibleChoicesSessionsList>> GetAvailableForStudent(Guid studentId);

        /// <summary>
        /// Get all sessions
        /// </summary>
        /// <returns></returns>
        Task<IReadOnlyCollection<SessionShortWithAvatar>> GetAll();
    }
}