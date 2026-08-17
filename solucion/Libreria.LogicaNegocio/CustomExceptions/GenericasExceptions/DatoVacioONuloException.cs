using System;
using System.Collections.Generic;
using System.Text;

namespace Libreria.LogicaNegocio.CustomExceptions.GenericasExceptions
{
    public class DatoVacioONuloException : Exception
    {

        public DatoVacioONuloException()
        {

        }

        public DatoVacioONuloException(string? message) : base(message)
        {
        }

        public DatoVacioONuloException(string? message, Exception? innerException)
            : base(message, innerException)
        {
        }


    }
}
