using Libreria.DTOs.DataTransferObjects.DTOsObservacionAstro;
using System;
using System.Collections.Generic;
using System.Text;

namespace Libreria.LogicaAplicacion.ICasosUso.ICUObservacionAstro
{
    public interface ICUAltaObservacion
    {
            void Alta(DTOAltaObservacion dto, DTOResultadoAltaObservacion resultado);
        
    }
}
