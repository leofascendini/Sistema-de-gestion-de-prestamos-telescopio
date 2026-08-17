using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Libreria.LogicaNegocio.CustomExceptions.UsuarioExceptions
{
    public class ApellidoIncorrectoException : Exception
    {
        public ApellidoIncorrectoException()
        {
        }

        public ApellidoIncorrectoException(string? message) : base(message)
        {
        }

        public ApellidoIncorrectoException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected ApellidoIncorrectoException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
