using System;

namespace JAG.Learnster.APIClient.Interfaces
{
    /// <summary>
    ///  Provider of Learnster Urls
    /// </summary>
    public interface ILearnsterUrlBuilder
    {
        /// <summary>
        /// Create url to image
        /// </summary>
        /// <param name="relativeUrl"></param>
        /// <returns></returns>
        Uri BuildImageUrl(string relativeUrl);
        
        /// <summary>
        /// Create url to course for users
        /// </summary>
        /// <param name="courseGuid"></param>
        /// <returns></returns>
        Uri BuildCourseUrl(Guid courseGuid);
    }
}