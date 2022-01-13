using System.Runtime.Serialization;

namespace JAG.Learnster.APIClient.Exceptions
{
	[Serializable]
	public class LearnsterException : Exception
	{
		public LearnsterException()
		{
		}

		public LearnsterException(string message) : base(message)
		{
		}

		public LearnsterException(string message, Exception innerException) : base(message, innerException)
		{
		}

		public LearnsterException(SerializationInfo info, StreamingContext context) : base(info, context)
		{
		}
	}
}