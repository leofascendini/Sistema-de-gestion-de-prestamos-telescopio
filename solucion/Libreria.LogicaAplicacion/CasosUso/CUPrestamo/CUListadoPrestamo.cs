using Libreria.DTOs.DataTransferObjects.DTOsPrestamo;
using Libreria.DTOs.Mappers;
using Libreria.LogicaAplicacion.ICasosUso.ICUPrestamo;
using Libreria.LogicaNegocio.CustomExceptions.PestamosExceptions;
using Libreria.LogicaNegocio.Entidades;
using Libreria.LogicaNegocio.IRepositorios;
using System;
using System.Collections.Generic;
using System.Text;

namespace Libreria.LogicaAplicacion.CasosUso.CUPrestamo
{
    public class CUPrestamoListado : ICUPrestamoListado
    {
        private readonly IRepositorioPrestamo _repoPrestamo;

        public CUPrestamoListado(IRepositorioPrestamo repoPrestamo)
        {
            _repoPrestamo = repoPrestamo;
        }

        public List<DTOPrestamoListado> ListarPrestamo(int UsuarioId)
        {
            var prestamos = _repoPrestamo.FindAll().Where(p => p.estado == EstadoPrestamo.Activo).ToList();

            if (!prestamos.Any())
                throw new PrestamoNoExisteExceptions("No hay prestamos activos");

            return prestamos.Select(p => MapperPrestamo.FromPrestamoToDTOListado(p)).ToList();
        }
    }
}
