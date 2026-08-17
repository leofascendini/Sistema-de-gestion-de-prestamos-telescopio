using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Libreria.LogicaNegocio.CustomExceptions.UsuarioExceptions
{
    public class NombreIncorrectoException : Exception
    {
        public NombreIncorrectoException()
        {
        }

        public NombreIncorrectoException(string? message) : base(message)
        {
        }

        public NombreIncorrectoException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected NombreIncorrectoException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
