using System;
using System.Runtime.Serialization;

namespace DriveLogCode.Exceptions
{
    internal class EmptyDataTableException : Exception
    {
        public EmptyDataTableException()
        {
        }

        public EmptyDataTableException(string message) : base(message)
        {
        }

        public EmptyDataTableException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected EmptyDataTableException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
