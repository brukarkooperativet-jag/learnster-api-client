using System;
using JAG.Learnster.APIClient.Interfaces;
using JAG.Learnster.APIClient.Options;
using Microsoft.Extensions.Options;

namespace JAG.Learnster.APIClient.Services
{
    /// <inheritdoc />
    public class LearnsterUrlBuilder : ILearnsterUrlBuilder
    {
        private readonly LearnsterOptions _learnsterOptions;

        public LearnsterUrlBuilder(IOptions<LearnsterOptions> learnsterOptions)
        {
            _learnsterOptions = learnsterOptions.Value;
        }

        /// <inheritdoc />
        public Uri BuildImageUrl(string relativeUrl)
            => BuildLearnsterUri(relativeUrl);

        /// <inheritdoc />
        public Uri BuildCourseUrl(Guid courseGuid)
            => BuildLearnsterUri($"{_learnsterOptions.VendorName}/sessions/{courseGuid}")!;

        private Uri BuildLearnsterUri(string relativeUri)
            => string.IsNullOrEmpty(relativeUri) ? null : new Uri(_learnsterOptions.Url, relativeUri);
    }
}