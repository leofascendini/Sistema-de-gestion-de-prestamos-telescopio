using Libreria.DTOs.DataTransferObjects.DTOsCamara;
using Libreria.LogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Libreria.DTOs.Mappers
{
    public class MapperCamara
    {
        public static DTOCamaraListado FromCamaraToDTOCamaraListado(Camara c)
        {
            DTOCamaraListado dto = new DTOCamaraListado();

            dto.EquipoId = c.EquipoId;
            dto.Nombre = c.marca + " " + c.modelo;
            dto.TipoSensor = c.tipoSensor;
            dto.Resolucion = c.resolucion;
            dto.TamañoPixel = c.tamañoPixel;

            return dto;
        }
    }
}
