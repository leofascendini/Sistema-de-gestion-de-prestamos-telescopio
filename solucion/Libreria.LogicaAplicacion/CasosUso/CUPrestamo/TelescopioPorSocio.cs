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
    public class CUListadoSociosPorTelescopio : ICUListadoSociosPorTelescopio
    {
        private IRepositorioPrestamo _repoPrestamo;

        public CUListadoSociosPorTelescopio(IRepositorioPrestamo repoPrestamo)
        {
            _repoPrestamo = repoPrestamo;
        }

        public List<DTOTelescopioPorSocio> ListarSociosPorTelescopio(int telescopioId)
        {
            var prestamos = _repoPrestamo.ObtenerSociosPorTelescopio(telescopioId);

            if (!prestamos.Any())
                throw new PrestamoNoExisteExceptions(
                    "No existen socios que hayan solicitado ese telescopio");

            return prestamos
                .Select(MapperUsuario.FromPrestamoToDTOTelescopioPorSocio)
                .ToList();
        }
    }
}
