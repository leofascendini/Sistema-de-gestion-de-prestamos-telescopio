using Libreria.DTOs.DataTransferObjects.DTOsMontura;
using Libreria.DTOs.Mappers;
using Libreria.LogicaAplicacion.ICasosUso.ICUMontura;
using Libreria.LogicaNegocio.Entidades;
using Libreria.LogicaNegocio.IRepositorios;
using System;
using System.Collections.Generic;
using System.Text;

namespace Libreria.LogicaAplicacion.CasosUso.CUMontura
{
    public class CUMonturaListado : ICUMonturaListado
    {
        private IRepositorioMontura _repoMontura;

        public CUMonturaListado(IRepositorioMontura repoMontura)
        {
            _repoMontura = repoMontura;
        }

        public List<DTOMonturaListado> Ejecutar()
        {
            IEnumerable<Montura> monturas = _repoMontura.FindAll();

            List<DTOMonturaListado> retornoMontura = new List<DTOMonturaListado>();

            foreach (Montura m in monturas)
            {
                retornoMontura.Add(
                    MapperMontura
                    .FromMonturaToDTOMonturaListado(m));
            }

            return retornoMontura;
        }
    }
}
