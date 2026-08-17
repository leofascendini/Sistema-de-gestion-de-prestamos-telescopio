using Libreria.DTOs.DataTransferObjects.DTOsTelescopio;
using Libreria.DTOs.Mappers;
using Libreria.LogicaAplicacion.ICasosUso.ICUTelescopio;
using Libreria.LogicaNegocio.Entidades;
using Libreria.LogicaNegocio.IRepositorios;
using System;
using System.Collections.Generic;
using System.Text;

namespace Libreria.LogicaAplicacion.CasosUso.CUTelescopio
{
    public class CUTelescopioListado : ICUTelescopioListado
    {
        private IRepositorioTelescopio _repoTelescopio;

        public CUTelescopioListado(IRepositorioTelescopio repoTelescopio)
        {
            _repoTelescopio = repoTelescopio;
        }

        public List<DTOTelescopioListado> Ejecutar()
        {
            IEnumerable<Telescopio> telescopios = _repoTelescopio.FindAll();

            List<DTOTelescopioListado> retorno =
                new List<DTOTelescopioListado>();

            foreach (Telescopio t in telescopios)
            {
                retorno.Add(
                    MapperTelescopio
                    .FromTelescopioToDTOTelescopioListado(t));
            }

            return retorno;
        }
    }
}
