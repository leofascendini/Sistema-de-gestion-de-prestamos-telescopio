using Libreria.DTOs.DataTransferObjects.DTOsEquipo;
using Libreria.LogicaAplicacion.ICasosUso.ICUEquipo;
using Libreria.LogicaNegocio.IRepositorios;
using System;
using System.Collections.Generic;
using System.Text;

namespace Libreria.LogicaAplicacion.CasosUso.CUEquipo
{
    public class CUEquipoDisponible : ICUEquipoDisponible
    {
        private readonly IRepositorioEquipo _repoEquipo;

        public CUEquipoDisponible(IRepositorioEquipo repoEquipo)
        {
            _repoEquipo = repoEquipo;
        }

        public DTOEquipoDisponible Ejecutar(int id)
        {
            var equipo = _repoEquipo.FindById(id);

            if (equipo == null)
                throw new Exception("Equipo no encontrado");

            return new DTOEquipoDisponible
            {
                EquipoId = equipo.EquipoId,
                Nombre = equipo.marca + " " + equipo.modelo,
                CantidadDisponible = equipo.cantidadDisponible,
                Disponible = equipo.cantidadDisponible > 0
            };
        }
    }
}
