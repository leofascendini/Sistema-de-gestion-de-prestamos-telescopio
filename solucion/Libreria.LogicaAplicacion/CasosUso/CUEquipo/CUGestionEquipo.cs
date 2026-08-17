using Libreria.DTOs.DataTransferObjects.DTOsEquipo;
using Libreria.DTOs.Mappers;
using Libreria.LogicaAplicacion.ICasosUso.ICUEquipo;
using Libreria.LogicaNegocio.CustomExceptions.EquipoExceptions;
using Libreria.LogicaNegocio.CustomExceptions.GenericasExceptions;
using Libreria.LogicaNegocio.Entidades;
using Libreria.LogicaNegocio.IRepositorios;
using System;
using System.Collections.Generic;
using System.Text;

namespace Libreria.LogicaAplicacion.CasosUso.CUEquipo

{
    public class CUGestionEquipo : ICUGestionEquipo
    {
        private IRepositorioEquipo _repoEquipo;
        private IRepositorioPrestamo _repoPrestamo;

        public CUGestionEquipo(IRepositorioEquipo repoEquipo, IRepositorioPrestamo repoPrestamo)
        {
            _repoEquipo = repoEquipo;
            _repoPrestamo = repoPrestamo;
        }

        public void Alta(DTOGestionEquipo dto)
        {
            if (string.IsNullOrWhiteSpace(dto.Marca))
                throw new DatoVacioONuloException("La marca es obligatoria");
            if (string.IsNullOrWhiteSpace(dto.Modelo))
                throw new DatoVacioONuloException("El modelo es obligatorio");
            if (dto.CantidadDisponible < 1)
                throw new ValorDebeSerMayorACeroException("La cantidad debe ser mayor 0");

            Equipo equipo = MapperEquipo.CrearEquipo(dto);
            _repoEquipo.Add(equipo);
        }
        public void Delete(int id)
        {
            var equipo = _repoEquipo.FindById(id);

            if (equipo == null)
                throw new EquipoNoExisteException("El equipo no existe");

            if (_repoPrestamo.EquipoEnPrestamo(id, equipo))
                throw new EquipoEnPrestamoException("No se puede eliminar el equipo porque esta en prestamo");

            _repoEquipo.Delete(id);
        }

        public void Edit(DTOGestionEquipo dto)
        {
            Equipo buscado = _repoEquipo.FindById(dto.EquipoId);

            if (buscado == null)
                throw new Exception("El equipo no existe");

            ValidacionesGenerales(dto);
            ValidarTelescopio(dto);
            ValidarMontura(dto);
            ValidarCamara(dto);
            ValidarOcular(dto);

            buscado.marca = dto.Marca;
            buscado.modelo = dto.Modelo;
            buscado.cantidadDisponible = dto.CantidadDisponible;

            if (buscado is Montura montura)
            {
                montura.tipoMontura = dto.TipoMontura.Value;
                montura.cargaUtil = dto.CargaUtil.Value;
                montura.esGoTo = dto.EsGoTo;
            }
            else if (buscado is Telescopio telescopio)
            {
                telescopio.apertura = dto.Apertura.Value;
                telescopio.relacionFocal = dto.RelacionFocal;
                telescopio.distanciaFocal = dto.DistanciaFocal.Value;
                telescopio.peso = dto.Peso.Value;
            }
            else if (buscado is Ocular ocular)
            {
                ocular.diametro = dto.Diametro.Value;
                ocular.anguloVision = dto.AnguloVision.Value;
            }
            else if (buscado is Camara camara)
            {
                camara.tipoSensor = dto.TipoSensor.Value;
                camara.resolucion = dto.Resolucion;
                camara.tamañoPixel = dto.TamañoPixel.Value;
            }

            _repoEquipo.Update(buscado);
        }

        public IEnumerable<DTOGestionEquipo> ObtenerTodos()
        {
            IEnumerable<Equipo> equipos = _repoEquipo.FindAll();

            return equipos.Select(e => MapperEquipo.ToDto(e));
        }
        public DTOGestionEquipo ObtenerPorId(int id)
        {
            Equipo equipo = _repoEquipo.FindById(id);

            if (equipo == null)
                throw new Exception("Equipo no encontrado");

            return MapperEquipo.ToDto(equipo);
        }
        private void ValidacionesGenerales(DTOGestionEquipo dto)
        {
            if (string.IsNullOrWhiteSpace(dto.Marca))
                throw new DatoVacioONuloException("La marca es obligatoria");
            if (dto.CantidadDisponible <= 0)
                throw new ValorDebeSerMayorACeroException("La cantidad disponible debe ser mayor a 0");
            if (dto.Peso < 0)
                throw new DatoVacioONuloException("El peso no puede ser negativo");
        }
        private void ValidarTelescopio(DTOGestionEquipo dto)
        {
            if (string.Equals(dto.TipoEquipo, "Telescopio", StringComparison.OrdinalIgnoreCase) && dto.Apertura == null)
                throw new DatoVacioONuloException("Debe indicar la apertura");

            if (string.Equals(dto.TipoEquipo, "Telescopio", StringComparison.OrdinalIgnoreCase) && dto.DistanciaFocal == null)
                throw new DatoVacioONuloException("Debe indicar la distancia focal");

            if (string.Equals(dto.TipoEquipo, "Telescopio", StringComparison.OrdinalIgnoreCase) && dto.Peso == null)
                throw new DatoVacioONuloException("Debe indicar el peso");

            if (string.Equals(dto.TipoEquipo, "Telescopio", StringComparison.OrdinalIgnoreCase) && dto.Apertura <= 0)
                throw new ValorDebeSerMayorACeroException("La apertura debe ser mayor a 0");

            if (string.Equals(dto.TipoEquipo, "Telescopio", StringComparison.OrdinalIgnoreCase) && dto.Peso < 0)
                throw new ValorDebeSerMayorACeroException("El peso no puede ser negativo");
        }
        private void ValidarMontura(DTOGestionEquipo dto)
        {
            if (string.Equals(dto.TipoEquipo, "Montura", StringComparison.OrdinalIgnoreCase) && dto.TipoMontura == null)
                throw new DatoVacioONuloException("Debe indicar el tipo de montura");

            if (string.Equals(dto.TipoEquipo, "Montura", StringComparison.OrdinalIgnoreCase) && dto.CargaUtil == null)
                throw new DatoVacioONuloException("Debe indicar la carga útil");

            if (string.Equals(dto.TipoEquipo, "Montura", StringComparison.OrdinalIgnoreCase) && dto.CargaUtil <= 0)
                throw new ValorDebeSerMayorACeroException("La carga útil debe ser mayor a 0");

        }
        private void ValidarCamara(DTOGestionEquipo dto)
        {
            if (string.Equals(dto.TipoEquipo, "Camara", StringComparison.OrdinalIgnoreCase))
            {
                if (dto.TipoSensor == null)
                    throw new DatoVacioONuloException("Debe indicar el tipo de sensor");

                if (string.IsNullOrWhiteSpace(dto.Resolucion))
                    throw new DatoVacioONuloException("Debe indicar la resolución");

                if (dto.TamañoPixel == null)
                    throw new DatoVacioONuloException("Debe indicar el tamaño del pixel");

                if (dto.TamañoPixel <= 0)
                    throw new ValorDebeSerMayorACeroException("El tamaño del pixel debe ser mayor a 0");
            }
        }
        private void ValidarOcular(DTOGestionEquipo dto)
        {
            if (string.Equals(dto.TipoEquipo, "Ocular", StringComparison.OrdinalIgnoreCase))
            {
                if (dto.Diametro == null)
                    throw new DatoVacioONuloException("Debe indicar el diámetro");

                if (dto.AnguloVision == null)
                    throw new DatoVacioONuloException("Debe indicar el ángulo de visión");

                if (dto.Diametro <= 0)
                    throw new ValorDebeSerMayorACeroException("El diámetro debe ser mayor a 0");

                if (dto.AnguloVision <= 0)
                    throw new ValorDebeSerMayorACeroException("El ángulo de visión debe ser mayor a 0");
            }
        }
    }
}
