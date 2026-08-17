using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Libreria.LogicaNegocio.CustomExceptions.PrestamoExceptions
{
    public class FechaNoEsValidaExceptions : Exception
    {
        public FechaNoEsValidaExceptions()
        {
        }

        public FechaNoEsValidaExceptions(string? message) : base(message)
        {
        }

        public FechaNoEsValidaExceptions(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected FechaNoEsValidaExceptions(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
