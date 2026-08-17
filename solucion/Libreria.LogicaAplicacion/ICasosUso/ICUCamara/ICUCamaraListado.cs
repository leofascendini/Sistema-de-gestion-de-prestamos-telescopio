using Libreria.DTOs.DataTransferObjects.DTOsCamara;
using Libreria.DTOs.DataTransferObjects.DTOsUsuario;
using System;
using System.Collections.Generic;
using System.Text;

namespace Libreria.LogicaAplicacion.ICasosUso.ICUCamara
{
    public interface ICUCamaraListado
    {
        List<DTOCamaraListado> Ejecutar();
    }
}
