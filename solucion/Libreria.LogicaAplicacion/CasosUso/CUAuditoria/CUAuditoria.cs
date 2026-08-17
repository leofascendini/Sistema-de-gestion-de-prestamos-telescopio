using Libreria.DTOs.DataTransferObjects.DTOsAuditoria;
using Libreria.DTOs.Mappers;
using Libreria.LogicaAplicacion.ICasosUso.ICUAuditoria;
using Libreria.LogicaNegocio.Entidades;
using Libreria.LogicaNegocio.IRepositorios;
using System;
using System.Collections.Generic;
using System.Text;

namespace Libreria.LogicaAplicacion.CasosUso.CUAuditoria
{
    public class CUAuditoria : ICUAuditoria
    {
        private readonly IRepositorioAuditoria _repoAuditoria;

        public CUAuditoria(IRepositorioAuditoria repo)
        {
            _repoAuditoria = repo;
        }

        public List<DTOAuditoriaPrestamo> Obtener(int? coordinadorId)
        {
            var data = coordinadorId.HasValue
                ? _repoAuditoria.GetByCoordinador(coordinadorId.Value)
                : _repoAuditoria.GetAll();

            if (data == null || !data.Any())
                return new List<DTOAuditoriaPrestamo>();

            return AuditoriaMapper.ToDTOList(data.ToList());
        }

        public List<DTOAuditoriaPrestamo> ObtenerPorPrestamo(int prestamoId)
        {
            if (prestamoId <= 0)
                return new List<DTOAuditoriaPrestamo>();

            var data = _repoAuditoria.GetByPrestamo(prestamoId);

            if (data == null || !data.Any())
                return new List<DTOAuditoriaPrestamo>();

            return AuditoriaMapper.ToDTOList(data.ToList());
        }
    }
}

