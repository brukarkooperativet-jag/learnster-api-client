using System;
using System.Runtime.Serialization;

namespace JAG.Learnster.APIClient.Exceptions
{
	/// <summary>
	/// Authentication failed exception
	/// </summary>
	[Serializable]
	public class AuthLearnsterException : Exception
	{
		/// <inheritdoc />
		public AuthLearnsterException()
		{
		}

		/// <inheritdoc />
		public AuthLearnsterException(string message) : base(message)
		{
		}

		/// <inheritdoc />
		public AuthLearnsterException(string message, Exception innerException) : base(message, innerException)
		{
		}

		/// <inheritdoc />
		public AuthLearnsterException(SerializationInfo info, StreamingContext context) : base(info, context)
		{
		}
	}
}