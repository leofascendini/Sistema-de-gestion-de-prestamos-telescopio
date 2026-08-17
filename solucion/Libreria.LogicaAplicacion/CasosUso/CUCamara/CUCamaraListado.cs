using Libreria.DTOs.DataTransferObjects.DTOsCamara;
using Libreria.DTOs.Mappers;
using Libreria.LogicaAplicacion.ICasosUso.ICUCamara;
using Libreria.LogicaNegocio.Entidades;
using Libreria.LogicaNegocio.IRepositorios;
using System;
using System.Collections.Generic;
using System.Text;

namespace Libreria.LogicaAplicacion.CasosUso.CUCamara
{
    public class CUCamaraListado : ICUCamaraListado
    {
        private IRepositorioCamara _repoCamara;

        public CUCamaraListado(IRepositorioCamara repoCamara)
        {
            _repoCamara = repoCamara;
        }

        public List<DTOCamaraListado> Ejecutar()
        {
            IEnumerable<Camara> camaras = _repoCamara.FindAll();

            List<DTOCamaraListado> retorno =
                new List<DTOCamaraListado>();

            foreach (Camara c in camaras)
            {
                retorno.Add(MapperCamara.FromCamaraToDTOCamaraListado(c));
            }

            return retorno;
        }
    }
}
