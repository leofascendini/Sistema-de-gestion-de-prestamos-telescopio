using Libreria.DTOs.DataTransferObjects.DTOsOcular;
using Libreria.LogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Libreria.DTOs.Mappers
{
    public class MapperOcular
    {
        public static DTOOcularListado FromOcularToDTOOcularListado(Ocular o)
        {
            DTOOcularListado dto = new DTOOcularListado();

            dto.EquipoId = o.EquipoId;

            dto.Nombre = o.marca + " " + o.modelo;

            return dto;
        }
    }
}
