using Libreria.DTOs.DataTransferObjects.DTOsObservacionAstro;
using System;
using System.Collections.Generic;
using System.Text;

namespace Libreria.LogicaAplicacion.ICasosUso.ICUObservacionAstro
{
  public interface ICUEvaluarObservacion
{
    Task<DTOResultadoAltaObservacion> Evaluar(DTOAltaObservacion dto,int usuarioId);
}
}
