using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Libreria.LogicaNegocio.CustomExceptions.PestamosExceptions
{
    public class PrestamoNoExisteExceptions : Exception
    {
        public PrestamoNoExisteExceptions()
        {
        }

        public PrestamoNoExisteExceptions(string? message) : base(message)
        {
        }

        public PrestamoNoExisteExceptions(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected PrestamoNoExisteExceptions(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
