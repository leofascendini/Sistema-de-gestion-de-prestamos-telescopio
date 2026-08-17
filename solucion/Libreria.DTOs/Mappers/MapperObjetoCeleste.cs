using Libreria.DTOs.DataTransferObjects.DTOsObjetoCeleste;
using Libreria.LogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Libreria.DTOs.Mappers
{
    public static class MapperObjetoCeleste
    {
        public static DTORankingObjetoCeleste
            FromObjetoCelesteToDTORanking(
                ObjetoCeleste objeto,
                int cantidadObservaciones)
        {
            return new DTORankingObjetoCeleste
            {
                Nombre = objeto.nombre,
                Tipo = objeto.tipo.ToString(),
                CantidadObservaciones = cantidadObservaciones
            };
        }
    }
}
