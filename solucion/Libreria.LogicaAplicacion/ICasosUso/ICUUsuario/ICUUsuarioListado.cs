using Libreria.DTOs.DataTransferObjects.DTOsUsuario;
using System;
using System.Collections.Generic;
using System.Text;

namespace Libreria.LogicaAplicacion.ICasosUso.ICUUsuario
{
    public interface ICUUsuarioListado
    {
        List<DTOUsuarioListado> Ejecutar();
    }
}
