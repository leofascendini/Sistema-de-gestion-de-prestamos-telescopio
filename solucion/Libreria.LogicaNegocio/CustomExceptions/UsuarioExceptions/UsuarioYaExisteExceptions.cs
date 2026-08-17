using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Libreria.LogicaNegocio.CustomExceptions.UsuarioExceptions
{
    public class UsuarioYaExisteExceptions : Exception
    {
        public UsuarioYaExisteExceptions()
        {
        }

        public UsuarioYaExisteExceptions(string? message) : base(message)
        {
        }

        public UsuarioYaExisteExceptions(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected UsuarioYaExisteExceptions(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
