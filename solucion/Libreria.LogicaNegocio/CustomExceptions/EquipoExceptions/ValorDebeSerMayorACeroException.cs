using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Libreria.LogicaNegocio.CustomExceptions.EquipoExceptions
{
    public class ValorDebeSerMayorACeroException : Exception
    {
        public ValorDebeSerMayorACeroException()
        {
        }

        public ValorDebeSerMayorACeroException(string? message) : base(message)
        {
        }

        public ValorDebeSerMayorACeroException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected ValorDebeSerMayorACeroException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

    }
}
