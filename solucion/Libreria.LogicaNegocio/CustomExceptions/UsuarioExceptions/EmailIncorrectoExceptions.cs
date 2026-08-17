using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Libreria.LogicaNegocio.CustomExceptions.UsuarioExceptions
{
    public class EmailIncorrectoExceptions : Exception
    {
        public EmailIncorrectoExceptions()
        {
        }

        public EmailIncorrectoExceptions(string? message) : base(message)
        {
        }

        public EmailIncorrectoExceptions(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected EmailIncorrectoExceptions(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
