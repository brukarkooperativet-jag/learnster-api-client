using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using JAG.Learnster.APIClient.Exceptions;
using JAG.Learnster.APIClient.Models.ApiContracts;
using JAG.Learnster.APIClient.Models.Requests;

namespace JAG.Learnster.APIClient.Interfaces
{
    /// <summary>
    /// Work with learnster students
    /// </summary>
    public interface ILearnsterStudentsClient
    {
        /// <summary>
        /// Get all students for vendor
        /// </summary>
        /// <returns></returns>
        /// <exception cref="LearnsterException">Throw when can't get students from the service</exception>
        Task<IReadOnlyCollection<VendorStudent>> GetAllStudents();

        /// <summary>
        /// Get student by email or identifier 
        /// </summary>
        /// <param name="searchString"></param>
        /// <returns></returns>
        Task<IReadOnlyCollection<VendorStudent>> SearchStudents(string searchString);

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