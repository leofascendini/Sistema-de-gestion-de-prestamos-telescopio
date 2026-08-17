using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Libreria.LogicaNegocio.CustomExceptions.PestamosExceptions
{
    public class PrestamoNoPerteneceAUsuarioExceptions : Exception
    {
        public PrestamoNoPerteneceAUsuarioExceptions()
        {
        }

        public PrestamoNoPerteneceAUsuarioExceptions(string? message) : base(message)
        {
        }

        public PrestamoNoPerteneceAUsuarioExceptions(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected PrestamoNoPerteneceAUsuarioExceptions(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
