using System;
using System.Runtime.Serialization;

namespace Cas.Common.WPF
{
    public class ViewRegistrationNotFoundException : Exception
    {
        public ViewRegistrationNotFoundException()
        {
        }

        public ViewRegistrationNotFoundException(string message) : base(message)
        {
        }

        public ViewRegistrationNotFoundException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected ViewRegistrationNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}