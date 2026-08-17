using Libreria.DTOs.DataTransferObjects.DTOsObservacionAstro;
using Libreria.LogicaAplicacion.ICasosUso.ICUObservacionAstro;
using Libreria.LogicaAplicacion.IServicios;
using Libreria.LogicaNegocio.CustomExceptions.ObjetoCelesteExceptions;
using Libreria.LogicaNegocio.CustomExceptions.PestamosExceptions;
using Libreria.LogicaNegocio.CustomExceptions.PrestamoExceptions;
using Libreria.LogicaNegocio.Entidades;
using Libreria.LogicaNegocio.IRepositorios;
using System;
using System.Collections.Generic;
using System.Text;

namespace Libreria.LogicaAplicacion.CasosUso.CUObservacionAstro
{
    public class CUEvaluarObservacion : ICUEvaluarObservacion
    {
        private IRepositorioPrestamo _repoPrestamo;
        private IRepositorioObjetoCeleste _repoObjeto;
        private IServicioGemini _servicioGemini;

        public CUEvaluarObservacion(
            IRepositorioPrestamo repoPrestamo,
            IRepositorioObjetoCeleste repoObjeto,
            IServicioGemini servicioGemini)
        {
            _repoPrestamo = repoPrestamo;
            _repoObjeto = repoObjeto;
            _servicioGemini = servicioGemini;
        }

        public async Task<DTOResultadoAltaObservacion> Evaluar(DTOAltaObservacion dto, int usuarioId)
        {
            var prestamo = _repoPrestamo.FindById(dto.PrestamoId);

            if (prestamo == null)
                throw new PrestamoNoExisteExceptions("El prestamo no existe");

            if (prestamo.UsuarioId != usuarioId)
                throw new PrestamoNoPerteneceAUsuarioExceptions("El prestamo no pertenece al usuario");

            if (prestamo.estado != EstadoPrestamo.Activo)
                throw new PrestamoNoEsActivoExceptions("El prestamo no se encuentra activo");

            if (prestamo.fechaFin < DateTime.Now)
                throw new FechaNoEsValidaExceptions("La fecha no es valida");

            var objeto = _repoObjeto.FindById(dto.ObjetoCelesteId);

            if (objeto == null)
                throw new ObjetoCelesteNoExisteExceptions("Objeto celeste no encontrado");

            return await _servicioGemini.EvaluarObservacion(prestamo, objeto);
        }
    }
}

