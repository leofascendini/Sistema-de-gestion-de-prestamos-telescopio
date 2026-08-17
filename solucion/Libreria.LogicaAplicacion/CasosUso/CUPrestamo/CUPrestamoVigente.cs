using Libreria.DTOs.DataTransferObjects.DTOsPrestamo;
using Libreria.DTOs.Mappers;
using Libreria.LogicaAplicacion.ICasosUso.ICUPrestamo;
using Libreria.LogicaNegocio.Entidades;
using Libreria.LogicaNegocio.IRepositorios;
using System;
using System.Collections.Generic;
using System.Text;

namespace Libreria.LogicaAplicacion.CasosUso.CUPrestamo
{
    public class CUPrestamosVigentes : ICUPrestamosVigentes
    {
        private IRepositorioPrestamo _repoPrestamo;

        public CUPrestamosVigentes(IRepositorioPrestamo repoPrestamo)
        {
            _repoPrestamo = repoPrestamo;
        }

        public List<DTOPrestamoListado> ListarPrestamosVigentes(int usuarioId)
        {
            return _repoPrestamo
                .FindAll()
                .Where(p =>
                    p.UsuarioId == usuarioId &&
                    p.estado == EstadoPrestamo.Activo)
                .Select(p => MapperPrestamo.FromPrestamoToDTOListado(p))
                .ToList();
        }
    }
}
