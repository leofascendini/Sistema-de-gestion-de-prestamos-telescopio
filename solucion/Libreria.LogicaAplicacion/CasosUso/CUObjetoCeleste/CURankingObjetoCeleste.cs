using Libreria.DTOs.DataTransferObjects.DTOsObjetoCeleste;
using Libreria.DTOs.Mappers;
using Libreria.LogicaAplicacion.ICasosUso.ICUObjetoCeleste;
using Libreria.LogicaNegocio.CustomExceptions.ObjetosObservadosExceptions;
using Libreria.LogicaNegocio.IRepositorios;
using System;
using System.Collections.Generic;
using System.Text;

namespace Libreria.LogicaAplicacion.CasosUso.CUObjetoCeleste
{
    public class CURankingObjetosCelestes : ICURankingObjetosCelestes
    {
        private IRepositorioObservacionAstro _repoObservacion;

        public CURankingObjetosCelestes(
            IRepositorioObservacionAstro repoObservacion)
        {
            _repoObservacion = repoObservacion;
        }
        public List<DTORankingObjetoCeleste> Ejecutar()
        {
            var objetos = _repoObservacion.ObtenerObjetosObservados();

            if (!objetos.Any())
            {
                throw new NoHayObjetosObservadosExceptions("No existen objetos celestes observados");
            }

            return objetos
                .GroupBy(o => o.ObjetoCelesteId)
                .Select(g =>
                    MapperObjetoCeleste.FromObjetoCelesteToDTORanking(
                        g.First(),
                        g.Count()))
                .OrderByDescending(x => x.CantidadObservaciones)
                .ToList();
        }
    }
}

