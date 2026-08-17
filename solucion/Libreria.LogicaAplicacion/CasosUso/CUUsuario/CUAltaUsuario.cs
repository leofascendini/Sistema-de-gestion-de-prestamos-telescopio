using Libreria.DTOs.DataTransferObjects.DTOsUsuario;
using Libreria.DTOs.Mappers;
using Libreria.LogicaAplicacion.ICasosUso.ICUUsuario;
using Libreria.LogicaNegocio.CustomExceptions.GenericasExceptions;
using Libreria.LogicaNegocio.CustomExceptions.UsuarioExceptions;
using Libreria.LogicaNegocio.Entidades;
using Libreria.LogicaNegocio.IRepositorios;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Libreria.LogicaAplicacion.CasosUso.CUUsuario
{
    public class CUAltaUsuario : ICUAltaUsuario
    {
        private IRepositorioUsuario _repoUsuario;
        private IRepositorioRol _repoRol;

        public CUAltaUsuario(IRepositorioUsuario repoUsuario, IRepositorioRol repoRol)
        {
            _repoUsuario = repoUsuario;
            _repoRol = repoRol;
        }

        public void Ejecutar(DTOAltaUsuario dto)
        {
            dto.Email = dto.Email.Trim().ToLower();
            if (dto == null)
                throw new DatoVacioONuloException("Los datos del usuario son obligatorios");

            if (string.IsNullOrWhiteSpace(dto.Nombre))
                throw new NombreIncorrectoException("El nombre es obligatorio");

            if (string.IsNullOrWhiteSpace(dto.Apellido))
                throw new ApellidoIncorrectoException("El apellido es obligatorio");

            if (string.IsNullOrWhiteSpace(dto.Direccion))
                throw new DireccionIncorrectoExceptions("La direccion es obligatorio");

            if (!Regex.IsMatch(dto.Email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
                throw new EmailIncorrectoExceptions("El email no tiene un formato valido");

            if (string.IsNullOrWhiteSpace(dto.NombreUsuario))
                throw new NombreIncorrectoException("El nombre de usuario es obligatorio");

            if (string.IsNullOrWhiteSpace(dto.Contraseña))
                throw new ContraseñaIncorrectaExceptions("La contraseña es obligatoria");

            if (dto.RolId <= 0)
                throw new RolIncorrectoException("Debe seleccionar un rol");

            Rol rol = _repoRol.FindById(dto.RolId);

            if (rol == null)
                throw new RolIncorrectoException("Rol invalido");

            Usuario buscado = _repoUsuario.FindByEmail(dto.Email);

            if (buscado != null)
                throw new UsuarioYaExisteExceptions();

            Usuario nuevo = MapperUsuario.FromDtoAltaPersonaToPersona(dto);

                nuevo.Contraseña = BCrypt.Net.BCrypt.HashPassword(nuevo.Contraseña);

                nuevo.Rol = rol;

                int idInsertado = _repoUsuario.Add(nuevo);
        }
    }
}
    

