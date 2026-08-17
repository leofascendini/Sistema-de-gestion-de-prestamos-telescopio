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
    public class CUAltaObservacion : ICUAltaObservacion
    {
        private IRepositorioPrestamo _repoPrestamo;
        private IRepositorioObjetoCeleste _repoObjeto;
        private IRepositorioObservacionAstro _repoObservacion;
        private IServicioGemini _servicioGemini;

        public CUAltaObservacion(IRepositorioPrestamo repoPrestamo, IRepositorioObjetoCeleste repoObjeto, IRepositorioObservacionAstro repoObservacion, IServicioGemini servicioGemini)
        {
            _repoPrestamo = repoPrestamo;
            _repoObjeto = repoObjeto;
            _repoObservacion = repoObservacion;
            _servicioGemini = servicioGemini;
        }

        public void Alta(DTOAltaObservacion dto, DTOResultadoAltaObservacion resultado)
        {
            var observacion = new ObservacionAstro
            {
                fechaObservacion = dto.FechaObservacion,
                PrestamoId = dto.PrestamoId,
                ObjetoCelesteId = dto.ObjetoCelesteId,
                ResultadoIA = resultado.Resultado,
                ExplicacionIA = resultado.ExplicacionIA
            };

            _repoObservacion.Add(observacion);
        }
    }
}
