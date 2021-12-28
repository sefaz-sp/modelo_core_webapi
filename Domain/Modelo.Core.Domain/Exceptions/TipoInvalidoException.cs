using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Modelo.Core.Domain.Exceptions
{
    public class TipoInvalidoException : ModeloBaseException
    {
        public TipoInvalidoException()
        {
        }

        public TipoInvalidoException(string message) : base(message)
        {
        }

        public TipoInvalidoException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected TipoInvalidoException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
