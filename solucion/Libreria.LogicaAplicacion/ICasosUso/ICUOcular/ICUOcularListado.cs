using Libreria.DTOs.DataTransferObjects.DTOsOcular;
using Libreria.DTOs.DataTransferObjects.DTOsUsuario;
using System;
using System.Collections.Generic;
using System.Text;

namespace Libreria.LogicaAplicacion.ICasosUso.ICUOcular
{
    public interface ICUOcularListado
    {
        List<DTOOcularListado> Ejecutar();
    }
}
