using JAG.Learnster.APIClient.Interfaces;

namespace JAG.Learnster.APIClient.Clients
{
    /// <inheritdoc />
    public class LearnsterClient : ILearnsterClient
    {
        /// <inheritdoc />
        public ILearnsterSessionsClient Sessions { get; }

        /// <inheritdoc />
        public ILearnsterStudentsClient Students { get; }

        /// <summary>
        /// 
        /// </summary>
        public LearnsterClient(ILearnsterSessionsClient sessionsClient,
                               ILearnsterStudentsClient studentsClient)
        {
            Sessions = sessionsClient;
            Students = studentsClient;
        }
    }
}