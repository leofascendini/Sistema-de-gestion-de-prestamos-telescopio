using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Libreria.LogicaNegocio.CustomExceptions.UsuarioExceptions
{
    public class DireccionIncorrectoExceptions : Exception
    {
        public DireccionIncorrectoExceptions()
        {
        }

        public DireccionIncorrectoExceptions(string? message) : base(message)
        {
        }

        public DireccionIncorrectoExceptions(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected DireccionIncorrectoExceptions(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
