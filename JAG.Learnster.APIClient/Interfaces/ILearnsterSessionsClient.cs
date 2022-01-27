using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using JAG.Learnster.APIClient.Models.ApiContracts;

namespace JAG.Learnster.APIClient.Interfaces
{
    /// <summary>
    /// Work with learnster sessions
    /// </summary>
    public interface ILearnsterSessionsClient
    {
        /// <summary>
        /// Get all available sessions for student
        /// </summary>
        /// <param name="studentId"></param>
        /// <returns></returns>
        Task<IReadOnlyCollection<PossibleChoicesSession>> GetAvailableForStudent(Guid studentId);

        /// <summary>
        /// Get all sessions
        /// </summary>
        /// <returns></returns>
        Task<IReadOnlyCollection<SessionShortWithAvatar>> GetAll();

        /// <summary>
        /// Get student courses
        /// </summary>
        /// <returns></returns>
        Task<IReadOnlyCollection<UserCourseParticipant>> GetStudentSessions(Guid studentId);
    }
}