using Libreria.LogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Libreria.LogicaNegocio.IRepositorios
{
    public interface IRepositorioPrestamo
    {
        IEnumerable<Prestamo> FindAll();
        Prestamo FindById(int id);
        void Update(Prestamo prestamo);
        void Add(Prestamo obj);
        bool EquipoEnPrestamo(int id, Equipo equipo);
        IEnumerable<Prestamo> ObtenerPrestamosSocioPorMesAnio(
            int usuarioId,
            int mes,
            int anio
            );

        IEnumerable<Prestamo> ObtenerSociosPorTelescopio(int telescopioId);
    }
}
