using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Libreria.LogicaNegocio.CustomExceptions.EquipoExceptions
{
    public class EquipoNoDisponibleException : Exception
    {
        public EquipoNoDisponibleException()
        {
        }

        public EquipoNoDisponibleException(string? message) : base(message)
        {
        }

        public EquipoNoDisponibleException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected EquipoNoDisponibleException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
