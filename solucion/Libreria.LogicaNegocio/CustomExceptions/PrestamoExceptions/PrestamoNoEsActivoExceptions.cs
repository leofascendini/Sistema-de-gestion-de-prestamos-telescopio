using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Libreria.LogicaNegocio.CustomExceptions.PrestamoExceptions
{
    public class PrestamoNoEsActivoExceptions : Exception
    {
        public PrestamoNoEsActivoExceptions()
        {
        }

        public PrestamoNoEsActivoExceptions(string? message) : base(message)
        {
        }

        public PrestamoNoEsActivoExceptions(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected PrestamoNoEsActivoExceptions(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
