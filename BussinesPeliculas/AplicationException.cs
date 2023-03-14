using System;
using System.Runtime.Serialization;

namespace BussinesPeliculas
{
    [Serializable]
    internal class AplicationException : Exception
    {
        public AplicationException()
        {
        }

        public AplicationException(string message) : base(message)
        {
        }

        public AplicationException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected AplicationException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}