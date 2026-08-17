using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Libreria.LogicaNegocio.CustomExceptions.UsuarioExceptions
{
    public class ContraseñaIncorrectaExceptions : Exception
    {
        public ContraseñaIncorrectaExceptions()
        {
        }

        public ContraseñaIncorrectaExceptions(string? message) : base(message)
        {
        }

        public ContraseñaIncorrectaExceptions(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected ContraseñaIncorrectaExceptions(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
