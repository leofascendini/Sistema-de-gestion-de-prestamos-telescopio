using Libreria.DTOs.DataTransferObjects.DTOsTelescopio;
using Libreria.DTOs.DataTransferObjects.DTOsUsuario;
using System;
using System.Collections.Generic;
using System.Text;

namespace Libreria.LogicaAplicacion.ICasosUso.ICUTelescopio
{
    public interface ICUTelescopioListado
    {
        List<DTOTelescopioListado> Ejecutar();
    }
}
