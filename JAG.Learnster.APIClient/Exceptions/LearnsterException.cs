using System;
using System.Runtime.Serialization;

namespace JAG.Learnster.APIClient.Exceptions
{
	/// <summary>
	/// Unprocessed learnster error exception
	/// </summary>
	[Serializable]
	public class LearnsterException : Exception
	{
		/// <inheritdoc />
		public LearnsterException()
		{
		}

		/// <inheritdoc />
		public LearnsterException(string message) : base(message)
		{
		}

		/// <inheritdoc />
		public LearnsterException(string message, Exception innerException) : base(message, innerException)
		{
		}

		/// <inheritdoc />
		public LearnsterException(SerializationInfo info, StreamingContext context) : base(info, context)
		{
		}
	}
}