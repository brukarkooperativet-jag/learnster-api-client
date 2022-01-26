using System;
using System.Runtime.Serialization;

namespace JAG.Learnster.APIClient.Exceptions
{
	/// <summary>
	/// Entity not found exception
	/// </summary>
	[Serializable]
	public class NotFoundLearnsterException : Exception
	{
		/// <inheritdoc />
		public NotFoundLearnsterException()
		{
		}

		/// <inheritdoc />
		public NotFoundLearnsterException(string message) : base(message)
		{
		}

		/// <inheritdoc />
		public NotFoundLearnsterException(string message, Exception innerException) : base(message, innerException)
		{
		}

		/// <inheritdoc />
		public NotFoundLearnsterException(SerializationInfo info, StreamingContext context) : base(info, context)
		{
		}
	}
}