using Libreria.DTOs.DataTransferObjects.DTOsPrestamo;
using Libreria.DTOs.DataTransferObjects.DTOsUsuario;
using Libreria.LogicaNegocio.Entidades;
using Libreria.LogicaNegocio.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Libreria.DTOs.Mappers
{
    public class MapperUsuario
    {
        public static Usuario FromDtoAltaPersonaToPersona(DTOAltaUsuario dto)
        {

            Usuario persona = new Usuario();
            persona.NombreCompleto = new NombreCompletoVO(dto.Nombre, dto.Apellido);
            persona.Direccion = dto.Direccion;
            persona.Telefono = dto.Telefono;
            persona.Email = dto.Email;
            persona.NombreUsuario = dto.NombreUsuario;
            persona.Contraseña = dto.Contraseña;
           
            return persona;
        }

        public static DTOUsuarioListado FromUsuarioToDTOUsuarioListado(Usuario u)
        {
            DTOUsuarioListado dto = new DTOUsuarioListado();

            dto.UsuarioId = u.UsuarioId;

            dto.Nombre = u.NombreCompleto.Nombre + " " + u.NombreCompleto.Apellido;

            return dto;
        }

        public static DTOTelescopioPorSocio FromPrestamoToDTOTelescopioPorSocio(Prestamo p)
        {
            return new DTOTelescopioPorSocio
            {
                UsuarioId = p.Usuario.UsuarioId,
                NombreCompleto = $"{p.Usuario.NombreCompleto.Nombre} {p.Usuario.NombreCompleto.Apellido}",
                Email = p.Usuario.Email,
                Telescopio = p.Telescopio.modelo
            };
        }
    }
}

