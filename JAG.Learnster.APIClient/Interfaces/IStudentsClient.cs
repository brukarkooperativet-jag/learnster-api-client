using JAG.Learnster.APIClient.Exceptions;
using JAG.Learnster.APIClient.Models;
using JAG.Learnster.APIClient.Models.ApiContracts;

namespace JAG.Learnster.APIClient.Interfaces
{
    public interface IStudentsClient
    {
        /// <summary>
        /// Get all students for vendor
        /// </summary>
        /// <returns></returns>
        /// <exception cref="LearnsterException">Throw when can't get students from the service</exception>
        Task<ResponseList<VendorStudents>> GetAllStudents();
    }
}