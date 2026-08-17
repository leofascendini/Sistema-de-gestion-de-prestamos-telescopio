using Libreria.DTOs.DataTransferObjects.DTOsMontura;
using Libreria.DTOs.DataTransferObjects.DTOsUsuario;
using System;
using System.Collections.Generic;
using System.Text;

namespace Libreria.LogicaAplicacion.ICasosUso.ICUMontura
{
    public interface ICUMonturaListado
    {
        List<DTOMonturaListado> Ejecutar();
    }
}
