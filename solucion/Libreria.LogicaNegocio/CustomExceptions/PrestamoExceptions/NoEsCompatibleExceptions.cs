using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Libreria.LogicaNegocio.CustomExceptions.PrestamoExceptions
{
    public class NoEsCompatibleExceptions : Exception
    {
        public NoEsCompatibleExceptions()
        {
        }

        public NoEsCompatibleExceptions(string? message) : base(message)
        {
        }

        public NoEsCompatibleExceptions(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected NoEsCompatibleExceptions(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
