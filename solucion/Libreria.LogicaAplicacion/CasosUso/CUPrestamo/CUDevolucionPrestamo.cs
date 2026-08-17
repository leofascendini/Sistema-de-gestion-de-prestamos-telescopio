using Libreria.DTOs.DataTransferObjects.DTOsPrestamo;
using Libreria.LogicaAplicacion.ICasosUso.ICUPrestamo;
using Libreria.LogicaNegocio.CustomExceptions.PestamosExceptions;
using Libreria.LogicaNegocio.CustomExceptions.PrestamoExceptions;
using Libreria.LogicaNegocio.Entidades;
using Libreria.LogicaNegocio.IRepositorios;
using System;
using System.Collections.Generic;
using System.Text;

namespace Libreria.LogicaAplicacion.CasosUso.CUPrestamo
{
    public class CUDevolucionPrestamo : ICUDevolucionPrestamo
    {
        private IRepositorioPrestamo _repoPrestamo;
        private IRepositorioAuditoria _repoAuditoria;
        private IRepositorioEquipo _repoEquipo;

        public CUDevolucionPrestamo(
            IRepositorioPrestamo repoPrestamo,
            IRepositorioAuditoria repoAuditoria,
            IRepositorioEquipo repoEquipo)
        {
            _repoPrestamo = repoPrestamo;
            _repoAuditoria = repoAuditoria;
            _repoEquipo = repoEquipo;
        }

        public void DevolverPrestamo(DTODevolucionPrestamo dto)
        {
            Prestamo prestamo = _repoPrestamo.FindById(dto.PrestamoId);

            if (prestamo == null)
                throw new PrestamoNoExisteExceptions("El prestamo no existe");

            if (prestamo.estado != EstadoPrestamo.Activo)
                throw new PrestamoNoEsActivoExceptions("El prestamo no esta en estado ACTIVO");

            var equipoIds = new List<(int? id, Equipo equipo)>
        {
            (prestamo.TelescopioId, _repoEquipo.FindById(prestamo.TelescopioId)),
            (prestamo.MonturaId, _repoEquipo.FindById(prestamo.MonturaId)),
            (prestamo.CamaraId, prestamo.CamaraId.HasValue ? _repoEquipo.FindById(prestamo.CamaraId.Value) : null),
            (prestamo.OcularId, prestamo.OcularId.HasValue ? _repoEquipo.FindById(prestamo.OcularId.Value) : null)
        };

            foreach (var item in equipoIds)
            {
                if (item.equipo != null)
                {
                    item.equipo.cantidadDisponible++;
                    _repoEquipo.Update(item.equipo);
                }
            }

            prestamo.estado = EstadoPrestamo.Devuelto;
            prestamo.fechaFin = dto.FechaDevolucion;

            _repoPrestamo.Update(prestamo);

            _repoAuditoria.Add(new Auditoria
            {
                Accion = "DEVOLUCION_PRESTAMO",
                Fecha = DateTime.Now,
                UsuarioCoordinadorId = prestamo.UsuarioId,
                PrestamoId = prestamo.PrestamoId,
                Observacion = dto.Observacion

            });
        }
    }
}
