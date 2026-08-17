using Libreria.DTOs.DataTransferObjects.DTOsPrestamo;
using Libreria.DTOs.Mappers;
using Libreria.LogicaAplicacion.ICasosUso.ICUPrestamo;
using Libreria.LogicaNegocio.CustomExceptions.EquipoExceptions;
using Libreria.LogicaNegocio.CustomExceptions.GenericasExceptions;
using Libreria.LogicaNegocio.CustomExceptions.PrestamoExceptions;
using Libreria.LogicaNegocio.Entidades;
using Libreria.LogicaNegocio.IRepositorios;
using System;
using System.Collections.Generic;
using System.Text;

namespace Libreria.LogicaAplicacion.CasosUso.CUPrestamo
{
    
        public class CUAltaPrestamo : ICUAltaPrestamo
        {
            private IRepositorioPrestamo _repoPrestamo;
            private IRepositorioAuditoria _repoAuditoria;
            private IRepositorioEquipo _repoEquipo;

        public CUAltaPrestamo(IRepositorioPrestamo repoPrestamo, IRepositorioAuditoria repoAuditoria, IRepositorioEquipo repoEquipo)
            {
                _repoPrestamo = repoPrestamo;
                _repoAuditoria = repoAuditoria;
                _repoEquipo = repoEquipo;
            }

        public void AltaPrestamo(DTOAltaPrestamo dto)
        {
            if (dto.UsuarioId <= 0)
                throw new DatoVacioONuloException("El usuario es obligatorio");

            if (dto.TelescopioId <= 0)
                throw new DatoVacioONuloException("El telescopio es obligatorio");

            if (dto.MonturaId <= 0)
                throw new DatoVacioONuloException("La montura es obligatoria");

            if (dto.FechaFin <= DateTime.Now)
                throw new DatoVacioONuloException("La fecha fin debe ser futura");

            if (dto.CamaraId == null && dto.OcularId == null)
                throw new DatoVacioONuloException("Debe solicitar camara u ocular");

            var telescopio = _repoEquipo.FindById(dto.TelescopioId)
                ?? throw new DatoVacioONuloException("Telescopio invalido");

            var montura = _repoEquipo.FindById(dto.MonturaId)
                ?? throw new DatoVacioONuloException("Montura invalida");

            var camara = dto.CamaraId.HasValue
                ? _repoEquipo.FindById(dto.CamaraId.Value)
                : null;

            var ocular = dto.OcularId.HasValue
                ? _repoEquipo.FindById(dto.OcularId.Value)
                : null;

            if (camara == null && dto.CamaraId.HasValue)
                throw new DatoVacioONuloException("Camara invalida");

            if (ocular == null && dto.OcularId.HasValue)
                throw new DatoVacioONuloException("Ocular invalido");

            if (telescopio.cantidadDisponible <= 0)
                throw new EquipoNoDisponibleException("Telescopio sin stock");

            if (montura.cantidadDisponible <= 0)
                throw new EquipoNoDisponibleException("Montura sin stock");

            if (camara != null && camara.cantidadDisponible <= 0)
                throw new EquipoNoDisponibleException("Camara sin stock");

            if (ocular != null && ocular.cantidadDisponible <= 0)
                throw new EquipoNoDisponibleException("Ocular sin stock");

            if (montura is Montura m)
            {
                if (m.tipoMontura != TipoMontura.Ecuatorial &&
                    m.tipoMontura != TipoMontura.Hibrida)
                {
                    throw new NoEsCompatibleExceptions(
                        "La montura debe ser ecuatorial o hibrida");
                }
            }

            if (telescopio is Telescopio t && montura is Montura m2)
            {
                if (t.peso > m2.cargaUtil)
                {
                    throw new PesoMayorACargaExceptions(
                        "La montura no soporta el peso del telescopio");
                }
            }

            var nuevo = MapperPrestamo.FromDTOAltaPrestamoToPrestamo(dto);

            nuevo.fechaInicio = DateTime.Now;
            nuevo.estado = EstadoPrestamo.Activo;

            _repoPrestamo.Add(nuevo);

            telescopio.cantidadDisponible--;
            _repoEquipo.Update(telescopio);

            montura.cantidadDisponible--;
            _repoEquipo.Update(montura);

            if (camara != null)
            {
                camara.cantidadDisponible--;
                _repoEquipo.Update(camara);
            }

            if (ocular != null)
            {
                ocular.cantidadDisponible--;
                _repoEquipo.Update(ocular);
            }

            _repoAuditoria.Add(new Auditoria
            {
                Accion = "ALTA_PRESTAMO",
                Fecha = DateTime.Now,
                UsuarioCoordinadorId = dto.UsuarioId,
                PrestamoId = nuevo.PrestamoId
            });
        }
    }
    }

