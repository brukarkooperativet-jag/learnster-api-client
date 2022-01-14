using System.Runtime.Serialization;

namespace JAG.Learnster.APIClient.Exceptions
{
	[Serializable]
	public class NotFoundLearnsterException : Exception
	{
		public NotFoundLearnsterException()
		{
		}

		public NotFoundLearnsterException(string message) : base(message)
		{
		}

		public NotFoundLearnsterException(string message, Exception innerException) : base(message, innerException)
		{
		}

		public NotFoundLearnsterException(SerializationInfo info, StreamingContext context) : base(info, context)
		{
		}
	}
}