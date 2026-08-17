using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Libreria.LogicaNegocio.CustomExceptions.EquipoExceptions
{
    public class EquipoEnPrestamoException : Exception
    {
        public EquipoEnPrestamoException()
        {
        }

        public EquipoEnPrestamoException(string? message) : base(message)
        {
        }

        public EquipoEnPrestamoException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected EquipoEnPrestamoException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

    }
}
