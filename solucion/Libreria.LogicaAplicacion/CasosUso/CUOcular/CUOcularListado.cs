using Libreria.DTOs.DataTransferObjects.DTOsOcular;
using Libreria.DTOs.Mappers;
using Libreria.LogicaAplicacion.ICasosUso.ICUOcular;
using Libreria.LogicaNegocio.Entidades;
using Libreria.LogicaNegocio.IRepositorios;
using System;
using System.Collections.Generic;
using System.Text;

namespace Libreria.LogicaAplicacion.CasosUso.CUOcular
{
    public class CUOcularListado : ICUOcularListado
    {
        private IRepositorioOcular _repoOcular;

        public CUOcularListado(IRepositorioOcular repoOcular)
        {
            _repoOcular = repoOcular;
        }

        public List<DTOOcularListado> Ejecutar()
        {
            IEnumerable<Ocular> oculares = _repoOcular.FindAll();

            List<DTOOcularListado> retorno =
                new List<DTOOcularListado>();

            foreach (Ocular o in oculares)
            {
                retorno.Add(
                    MapperOcular
                    .FromOcularToDTOOcularListado(o));
            }

            return retorno;
        }
    }
}
