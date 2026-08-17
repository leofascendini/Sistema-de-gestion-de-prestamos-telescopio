using System;
using System.Collections.Generic;
using System.Text;

namespace Libreria.DTOs.DataTransferObjects.DTOsObservacionAstro
{
    public class DTOConfirmarObservacionRequest
    {
        public DTOAltaObservacion AltaObservacion { get; set; }
        public DTOResultadoAltaObservacion Resultado { get; set; }
    }
}
