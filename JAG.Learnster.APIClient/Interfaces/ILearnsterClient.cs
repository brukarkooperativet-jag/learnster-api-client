namespace JAG.Learnster.APIClient.Interfaces
{
    /// <summary>
    /// Base client to work with learnster
    /// </summary>
    public interface ILearnsterClient
    {
        /// <summary>
        /// Sessions
        /// </summary>
        ILearnsterSessionsClient Sessions { get; }

        /// <summary>
        /// Students
        /// </summary>
        ILearnsterStudentsClient Students { get; }
    }
}