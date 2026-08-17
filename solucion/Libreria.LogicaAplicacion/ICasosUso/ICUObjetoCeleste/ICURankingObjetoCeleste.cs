using Libreria.DTOs.DataTransferObjects.DTOsObjetoCeleste;
using System;
using System.Collections.Generic;
using System.Text;

namespace Libreria.LogicaAplicacion.ICasosUso.ICUObjetoCeleste
{
    public interface ICURankingObjetosCelestes
    {
        List<DTORankingObjetoCeleste> Ejecutar();
    }
}
