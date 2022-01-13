using System.Runtime.Serialization;

namespace JAG.Learnster.APIClient.Exceptions
{
	[Serializable]
	public class AuthLearnsterException : Exception
	{
		public AuthLearnsterException()
		{
		}

		public AuthLearnsterException(string message) : base(message)
		{
		}

		public AuthLearnsterException(string message, Exception innerException) : base(message, innerException)
		{
		}

		public AuthLearnsterException(SerializationInfo info, StreamingContext context) : base(info, context)
		{
		}
	}
}