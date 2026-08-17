using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Libreria.LogicaNegocio.CustomExceptions.UsuarioExceptions
{
    public class RolIncorrectoException : Exception
    {
        public RolIncorrectoException()
        {
        }

        public RolIncorrectoException(string? message) : base(message)
        {
        }

        public RolIncorrectoException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected RolIncorrectoException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
