using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Libreria.LogicaNegocio.CustomExceptions.EquipoExceptions
{
    public class EquipoNoExisteException : Exception
    {
        public EquipoNoExisteException()
        {
        }

        public EquipoNoExisteException(string? message) : base(message)
        {
        }

        public EquipoNoExisteException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected EquipoNoExisteException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

    }
}
