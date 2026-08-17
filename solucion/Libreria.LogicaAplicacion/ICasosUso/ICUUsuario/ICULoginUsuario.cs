using Libreria.DTOs.DataTransferObjects.DTOsUsuario;
using Libreria.LogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Libreria.LogicaAplicacion.ICasosUso.ICUUsuario
{
    public interface ICULoginUsuario
    {
        Usuario Ejecutar(DTOLoginUsuario dto);
    }
}
