using Libreria.LogicaNegocio.CustomExceptions.GenericasExceptions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Libreria.LogicaNegocio.ValueObjects
{
    [ComplexType]
    public record NombreCompletoVO
    {
        public string Nombre { get; init; }
        public string Apellido { get; init; }

        public NombreCompletoVO()
        {

        }
        public NombreCompletoVO(string n, string a)
        {
            if (String.IsNullOrEmpty(n))
            {
                throw new DatoVacioONuloException("El nombre es vacío");

            }
            if (String.IsNullOrEmpty(a))
            {
                throw new DatoVacioONuloException("El apellido es vacío");

            }
            Nombre = n;
            Apellido = a;
        }
    }
}

