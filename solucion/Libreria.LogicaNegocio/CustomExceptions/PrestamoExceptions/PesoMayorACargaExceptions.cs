using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Libreria.LogicaNegocio.CustomExceptions.PrestamoExceptions
{
    public class PesoMayorACargaExceptions : Exception
    {
        public PesoMayorACargaExceptions()
        {
        }

        public PesoMayorACargaExceptions(string? message) : base(message)
        {
        }

        public PesoMayorACargaExceptions(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected PesoMayorACargaExceptions(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
