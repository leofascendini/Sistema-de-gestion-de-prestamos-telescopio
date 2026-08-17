using Libreria.LogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Libreria.LogicaAplicacion.IServicios
{
    public interface IServicioAuth
    {
        string GenerarToken(Usuario usuario);
    }
}
