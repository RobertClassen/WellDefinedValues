namespace System
{
	using Collections;
	using Collections.Generic;
	using Runtime.Serialization;

	public class ArgumentLessEqualsZeroException : ArgumentOutOfRangeException
	{
		#region Constants
		public const string DefaultMessage = "Argument must be greater than zero";
		#endregion

		#region Fields
		
		#endregion

		#region Properties

		#endregion

		#region Constructors
		public ArgumentLessEqualsZeroException()
		{
		}

		public ArgumentLessEqualsZeroException(SerializationInfo info, StreamingContext context) :
			base(info, context)
		{
		}

		public ArgumentLessEqualsZeroException(string paramName) :
			base(paramName)
		{
		}

		public ArgumentLessEqualsZeroException(string message, Exception innerException) :
			base(message, innerException)
		{
		}

		public ArgumentLessEqualsZeroException(string paramName, object actualValue, string message = DefaultMessage) :
			base(paramName, actualValue, message)
		{
		}

		public ArgumentLessEqualsZeroException(string paramName, string message = DefaultMessage) :
			base(paramName, message)
		{
		}
		#endregion

		#region Methods
		
		#endregion
	}
}