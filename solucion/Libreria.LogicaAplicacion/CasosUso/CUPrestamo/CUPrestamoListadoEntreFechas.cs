using Libreria.DTOs.DataTransferObjects.DTOsPrestamo;
using Libreria.DTOs.Mappers;
using Libreria.LogicaAplicacion.ICasosUso.ICUPrestamo;
using Libreria.LogicaNegocio.CustomExceptions.PestamosExceptions;
using Libreria.LogicaNegocio.IRepositorios;
using System;
using System.Collections.Generic;
using System.Text;

namespace Libreria.LogicaAplicacion.CasosUso.CUPrestamo
{
    public class CUPrestamoListadoEntreFechas : ICUPrestamoListadoEntreFechas
    {
        private IRepositorioPrestamo _repoPrestamo;

        public CUPrestamoListadoEntreFechas(IRepositorioPrestamo repoPrestamo)
        {
            _repoPrestamo = repoPrestamo;
        }

        public List<DTOPrestamoListado> ListarPrestamoEntreFechas(int usuarioId, int mes, int anio)
        {
            var prestamos = _repoPrestamo.ObtenerPrestamosSocioPorMesAnio(usuarioId, mes, anio);

            if (!prestamos.Any())
                throw new PrestamoNoExisteExceptions("No existen prestamos para la fecha seleccionada");

            return prestamos.Select(MapperPrestamo.FromPrestamoToDTOListado).ToList();
        }
    }
}
