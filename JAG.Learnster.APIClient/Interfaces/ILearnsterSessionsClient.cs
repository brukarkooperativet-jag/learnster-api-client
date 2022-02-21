using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using JAG.Learnster.APIClient.Models;
using JAG.Learnster.APIClient.Models.ApiContracts;

namespace JAG.Learnster.APIClient.Interfaces
{
    /// <summary>
    /// Work with learnster sessions
    /// </summary>
    public interface ILearnsterSessionsClient
    {
        /// <summary>
        /// Get all sessions
        /// </summary>
        /// <returns></returns>
        Task<IReadOnlyCollection<SessionShortWithAvatar>> GetAll();

        /// <summary>
        /// Get list of sessions
        /// </summary>
        /// <param name="page"></param>
        /// <param name="count">Max 100</param>
        /// <returns></returns>
        Task<ResponseList<SessionShortWithAvatar>> Get(int page, int count);

        /// <summary>
        /// Get student sessions
        /// </summary>
        /// <returns></returns>
        Task<IReadOnlyCollection<SessionParticipant>> GetStudentSessions(Guid studentId);

        /// <summary>
        /// Get all available sessions for student
        /// </summary>
        /// <param name="studentId"></param>
        /// <param name="isCatalog"></param>
        /// <returns></returns>
        Task<IReadOnlyCollection<PossibleChoicesSession>> GetAvailableForStudent(Guid studentId, bool? isCatalog = null);

        /// <summary>
        /// Get student sessions history
        /// </summary>
        /// <returns></returns>
        Task<IReadOnlyCollection<StudentHistory>> GetStudentSessionsHistory(Guid studentId);
    }
}