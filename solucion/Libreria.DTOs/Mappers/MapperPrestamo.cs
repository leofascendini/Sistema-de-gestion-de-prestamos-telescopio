using Libreria.DTOs.DataTransferObjects.DTOsPrestamo;
using Libreria.LogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Libreria.DTOs.Mappers
{
    public class MapperPrestamo
    {
        public static Prestamo FromDTOAltaPrestamoToPrestamo(DTOAltaPrestamo dto)
        {
            return new Prestamo
            {
                fechaInicio = DateTime.Now,

                fechaFin = dto.FechaFin,

                estado = EstadoPrestamo.Activo,

                UsuarioId = dto.UsuarioId,

                TelescopioId = dto.TelescopioId,

                MonturaId = dto.MonturaId,

                CamaraId = dto.CamaraId,

                OcularId = dto.OcularId
            };
        }

        public static DTOPrestamoListado FromPrestamoToDTOListado(Prestamo p)
        {
            return new DTOPrestamoListado
            {
                PrestamoId = p.PrestamoId,

                Usuario = p.Usuario.NombreCompleto.Nombre + " " + p.Usuario.NombreCompleto.Apellido,

                Telescopio = p.Telescopio != null
                    ? $"{p.Telescopio.marca} {p.Telescopio.modelo}"
                    : "-",

                Montura = p.Montura != null
                    ? $"{p.Montura.marca} {p.Montura.modelo}"
                    : "-",

                Camara = p.Camara != null
                    ? $"{p.Camara.marca} {p.Camara.modelo}"
                    : "-",

                Ocular = p.Ocular != null
                    ? $"{p.Ocular.marca} {p.Ocular.modelo}"
                    : "-",

                FechaInicio = p.fechaInicio,
                FechaFin = p.fechaFin,

                Estado = p.estado.ToString(),

                EstaAtrasado = p.estado == EstadoPrestamo.Activo && DateTime.Now > p.fechaFin
            };
        }
    }
}

