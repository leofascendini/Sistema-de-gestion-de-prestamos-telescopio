using System;
using System.Collections.Generic;
using System.Text;

namespace Libreria.LogicaNegocio.CustomExceptions.ObjetoCelesteExceptions
{
    public class ObjetoCelesteNoExisteExceptions : Exception
    {

        public ObjetoCelesteNoExisteExceptions()
        {

        }

        public ObjetoCelesteNoExisteExceptions(string? message) : base(message)
        {
        }

        public ObjetoCelesteNoExisteExceptions(string? message, Exception? innerException)
            : base(message, innerException)
        {
        }


    }
}
