using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Modelo.Core.Domain.Exceptions
{
    public class RegistroNuloException : ModeloBaseException
    {
        public RegistroNuloException()
        {
        }

        public RegistroNuloException(string message) : base(message)
        {
        }

        public RegistroNuloException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected RegistroNuloException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
