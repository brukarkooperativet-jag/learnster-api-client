using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using JAG.Learnster.APIClient.Exceptions;
using JAG.Learnster.APIClient.Models.ApiContracts;
using JAG.Learnster.APIClient.Models.Requests.Student;
using JetBrains.Annotations;

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
        Task<IReadOnlyCollection<VendorStudent>> GetAll();

        /// <summary>
        /// Get student by email or identifier 
        /// </summary>
        /// <param name="searchString"></param>
        /// <returns></returns>
        Task<IReadOnlyCollection<VendorStudent>> SearchStudents(string searchString);

        /// <summary>
        /// Get student by personal Id
        /// </summary>
        /// <param name="personalId"></param>
        /// <returns></returns>
        [ItemCanBeNull]
        Task<VendorStudent> GetStudentByPersonalId(string personalId);
        
        /// <summary>
        /// Create user and student
        /// </summary>
        /// <param name="createStudentRequest"></param>
        /// <returns>Created user and student</returns>
        /// <exception cref="LearnsterException">Throw when can't create student in the system</exception>
        Task<VendorStudent> CreateStudent(CreateStudentRequest createStudentRequest);

        /// <summary>
        /// Update user and student
        /// </summary>
        /// <param name="updateStudentRequest"></param>
        /// <returns></returns>
        /// <exception cref="NotFoundLearnsterException">Cant find student in the system</exception>
        /// <exception cref="LearnsterException">Throw when can't update student in the system</exception>
        Task<VendorStudent> UpdateStudent(UpdateStudentRequest updateStudentRequest);

        /// <summary>
        /// Delete user and student
        /// </summary>
        /// <param name="studentId"></param>
        /// <exception cref="LearnsterException">Throw when can't delete</exception>
        Task DeleteStudent(Guid studentId);

        /// <summary>
        /// Mark student as disabled
        /// </summary>
        /// <param name="studentId"></param>
        /// <returns></returns>
        /// <exception cref="NotFoundLearnsterException">Cant find student in the system</exception>
        /// <exception cref="LearnsterException">Throw when can't update student in the system</exception>
        Task<VendorStudent> DeactivateStudent(Guid studentId);

        /// <summary>
        /// Mark student as enabled
        /// </summary>
        /// <param name="studentId"></param>
        /// <returns></returns>
        /// <exception cref="NotFoundLearnsterException">Cant find student in the system</exception>
        /// <exception cref="LearnsterException">Throw when can't update student in the system</exception>
        Task<VendorStudent> ActivateStudent(Guid studentId);
    }
}