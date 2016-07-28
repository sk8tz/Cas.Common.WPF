using System;
using System.Runtime.Serialization;

namespace Cas.Common.WPF
{
    public class ViewModelException : Exception
    {
        public ViewModelException()
        {
        }

        public ViewModelException(string message) : base(message)
        {
        }

        public ViewModelException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected ViewModelException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}