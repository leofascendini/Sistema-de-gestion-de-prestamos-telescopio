using Libreria.DTOs.DataTransferObjects.DTOsMontura;
using Libreria.LogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Libreria.DTOs.Mappers
{
    public class MapperMontura
    {
        public static DTOMonturaListado
            FromMonturaToDTOMonturaListado(Montura m)
        {
            DTOMonturaListado dto = new DTOMonturaListado();

            dto.EquipoId = m.EquipoId;
            dto.Nombre = m.marca + " " + m.modelo;
            dto.tipoMontura = m.tipoMontura;
            dto.cargaUtil = m.cargaUtil;

            return dto;
        }
    }
}
