using Libreria.DTOs.DataTransferObjects.DTOsUsuario;
using Libreria.LogicaAplicacion.ICasosUso.ICUUsuario;
using Libreria.LogicaNegocio.CustomExceptions.GenericasExceptions;
using Libreria.LogicaNegocio.Entidades;
using Libreria.LogicaNegocio.IRepositorios;
using System;
using System.Collections.Generic;
using System.Text;

namespace Libreria.LogicaAplicacion.CasosUso.CUUsuario
{
    public class CULoginUsuario : ICULoginUsuario
    {
        private IRepositorioUsuario _repoUsuario;

        public CULoginUsuario(IRepositorioUsuario repoUsuario)
        {
            _repoUsuario = repoUsuario;
        }

        public Usuario Ejecutar(DTOLoginUsuario dto)
        {
            Usuario usuario = _repoUsuario.FindByEmail(dto.Email);
            if (usuario == null)
                throw new DatoVacioONuloException("Usuario incorrecto");

            if (!BCrypt.Net.BCrypt.Verify(dto.Contraseña, usuario.Contraseña))
                throw new DatoVacioONuloException("Contraseña incorrecta");
            return usuario;
        }
    }
}
