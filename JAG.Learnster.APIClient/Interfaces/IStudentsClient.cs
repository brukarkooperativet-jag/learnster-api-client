using JAG.Learnster.APIClient.Exceptions;
using JAG.Learnster.APIClient.Models;
using JAG.Learnster.APIClient.Models.ApiContracts;
using JAG.Learnster.APIClient.Models.Requests;

namespace JAG.Learnster.APIClient.Interfaces
{
    public interface IStudentsClient
    {
        /// <summary>
        /// Get all students for vendor
        /// </summary>
        /// <returns></returns>
        /// <exception cref="LearnsterException">Throw when can't get students from the service</exception>
        Task<ResponseList<VendorStudent>> GetAllStudents();

        /// <summary>
        /// Create user and student
        /// </summary>
        /// <param name="createUserRequest"></param>
        /// <returns>Created user and student</returns>
        /// <exception cref="LearnsterException">Throw when can't create student in the system</exception>
        Task<VendorStudent> CreateStudent(CreateUserRequest createUserRequest);

        /// <summary>
        /// Delete user and student
        /// </summary>
        /// <param name="studentId"></param>
        /// <exception cref="LearnsterException">Throw when can't delete</exception>
        Task DeleteStudent(Guid studentId);
    }
}