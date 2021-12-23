using System;
using System.Runtime.Serialization;

namespace Modelo.Core.Domain.Exceptions
{
    public class ModeloBaseException : Exception
    {
        public ModeloBaseException()
        {
        }

        public ModeloBaseException(string message) : base(message)
        {
        }

        public ModeloBaseException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected ModeloBaseException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
