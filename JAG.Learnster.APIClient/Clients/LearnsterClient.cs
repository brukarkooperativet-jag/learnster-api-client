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

        /// <inheritdoc />
        public ILearnsterTeamClient Teams { get; }

        public LearnsterClient(ILearnsterSessionsClient sessionsClient,
                               ILearnsterStudentsClient studentsClient,
                               ILearnsterTeamClient teamsClient)
        {
            Sessions = sessionsClient;
            Students = studentsClient;
            Teams = teamsClient;
        }
    }
}