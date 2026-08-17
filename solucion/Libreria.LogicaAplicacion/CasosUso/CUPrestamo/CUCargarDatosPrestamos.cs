using Libreria.DTOs.DataTransferObjects.DTOsPrestamo;
using Libreria.DTOs.Mappers;
using Libreria.LogicaAplicacion.ICasosUso.ICUPrestamo;
using Libreria.LogicaNegocio.IRepositorios;
using System;
using System.Collections.Generic;
using System.Text;

namespace Libreria.LogicaAplicacion.CasosUso.CUPrestamo
{
    public class CUCargarDatosPrestamo : ICUCargarDatosPrestamo
    {
        private IRepositorioUsuario _repoUsuario;
        private IRepositorioTelescopio _repoTelescopio;
        private IRepositorioMontura _repoMontura;
        private IRepositorioCamara _repoCamara;
        private IRepositorioOcular _repoOcular;

        public CUCargarDatosPrestamo(
            IRepositorioUsuario repoUsuario,
            IRepositorioTelescopio repoTelescopio,
            IRepositorioMontura repoMontura,
            IRepositorioCamara repoCamara,
            IRepositorioOcular repoOcular)
        {
            _repoUsuario = repoUsuario;
            _repoTelescopio = repoTelescopio;
            _repoMontura = repoMontura;
            _repoCamara = repoCamara;
            _repoOcular = repoOcular;
        }

        public DTOPrestamoFormulario Ejecutar()
        {
            return new DTOPrestamoFormulario
            {
                Usuarios = _repoUsuario.FindAll().Select(u => MapperUsuario.FromUsuarioToDTOUsuarioListado(u)).ToList(),

                Telescopios = _repoTelescopio.FindAll().Select(t => MapperTelescopio.FromTelescopioToDTOTelescopioListado(t)).ToList(),

                Monturas = _repoMontura.FindAll().Select(m => MapperMontura.FromMonturaToDTOMonturaListado(m)).ToList(),

                Camaras = _repoCamara.FindAll().Select(c => MapperCamara.FromCamaraToDTOCamaraListado(c)).ToList(),

                Oculares = _repoOcular.FindAll().Select(o => MapperOcular.FromOcularToDTOOcularListado(o)).ToList()
            };
        }
    }
}
