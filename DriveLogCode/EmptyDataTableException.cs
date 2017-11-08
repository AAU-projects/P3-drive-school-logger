using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DriveLogCode
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
