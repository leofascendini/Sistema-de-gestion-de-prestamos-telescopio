using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Libreria.LogicaNegocio.CustomExceptions.ObjetosObservadosExceptions
{
    public class NoHayObjetosObservadosExceptions : Exception
    {
        public NoHayObjetosObservadosExceptions()
        {
        }

        public NoHayObjetosObservadosExceptions(string? message) : base(message)
        {
        }

        public NoHayObjetosObservadosExceptions(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected NoHayObjetosObservadosExceptions(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
