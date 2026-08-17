using Libreria.DTOs.DataTransferObjects.DTOsTelescopio;
using Libreria.LogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Libreria.DTOs.Mappers
{
    public class MapperTelescopio
    {
        public static DTOTelescopioListado FromTelescopioToDTOTelescopioListado(Telescopio t)
        {
            DTOTelescopioListado dto = new DTOTelescopioListado();

            dto.EquipoId = t.EquipoId;
            dto.Nombre = t.marca + " " + t.modelo;

            return dto;
        }
    }

}

