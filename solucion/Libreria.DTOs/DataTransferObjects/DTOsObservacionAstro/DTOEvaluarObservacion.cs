using Libreria.LogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Libreria.DTOs.DataTransferObjects.DTOsObservacionAstro
{
    public class DTOAltaObservacion
    {
        public int PrestamoId { get; set; }
        public int ObjetoCelesteId { get; set; }
        public DateTime FechaObservacion { get; set; }
    }

    public class DTOResultadoAltaObservacion
    {
        public ResultadoObservacion Resultado { get; set; }
        public string ExplicacionIA { get; set; }
    }
}
