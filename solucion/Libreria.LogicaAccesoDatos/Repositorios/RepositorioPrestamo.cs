using Libreria.AccesoDatos;
using Libreria.LogicaNegocio.Entidades;
using Libreria.LogicaNegocio.IRepositorios;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Libreria.AccesoDatos.Repositorios
{
    public class RepositorioPrestamo : IRepositorioPrestamo
    {
        private ApplicationDbContext _context;

        public RepositorioPrestamo(ApplicationDbContext context)
        {
            _context = context;
        }
        public IEnumerable<Prestamo> FindAll()
        {
            return _context.Set<Prestamo>()
                .Include(p => p.Usuario)
                .Include(p => p.Telescopio)
                .Include(p => p.Montura)
                .Include(p => p.Camara)
                .Include(p => p.Ocular)
                .ToList();
        }
        public bool EquipoEnPrestamo(int id, Equipo equipo)
        {
            return _context.Set<Prestamo>().Any(p =>
                p.estado == EstadoPrestamo.Activo &&
                (
                    (equipo is Telescopio && p.TelescopioId == id) ||
                    (equipo is Montura && p.MonturaId == id) ||
                    (equipo is Camara && p.CamaraId == id) ||
                    (equipo is Ocular && p.OcularId == id)
                )
            );
        }
        public Prestamo FindById(int id)
        {
            return _context.Set<Prestamo>()
                .Include(p => p.Usuario)
                .Include(p => p.Telescopio)
                .Include(p => p.Montura)
                .Include(p => p.Camara)
                .Include(p => p.Ocular)
                .FirstOrDefault(p => p.PrestamoId == id);
        }
        public void Add(Prestamo obj)
        {
            _context.Prestamos.Add(obj);
            _context.SaveChanges();
        }
        public void Update(Prestamo prestamo)
        {
            _context.Set<Prestamo>().Update(prestamo);
            _context.SaveChanges();
        }
        public IEnumerable<Prestamo> ObtenerPrestamosSocioPorMesAnio(
                int usuarioId,
                int mes,
                int anio)
        {
            return _context.Set<Prestamo>()
                .Include(p => p.Usuario)
                .Include(p => p.Telescopio)
                .Include(p => p.Montura)
                .Include(p => p.Camara)
                .Include(p => p.Ocular)
                .Where(p =>
                    p.UsuarioId == usuarioId &&
                    p.fechaInicio.Month == mes &&
                    p.fechaInicio.Year == anio)
                .ToList();
        }
        public IEnumerable<Prestamo> ObtenerSociosPorTelescopio(int telescopioId)
        {
            return _context.Prestamos
                .Include(p => p.Usuario)
                .Include(p => p.Telescopio)
                .Where(p => p.TelescopioId == telescopioId)
                .ToList()
                .GroupBy(p => p.UsuarioId)
                .Select(g => g.First())
                .OrderByDescending(p => p.Usuario.NombreCompleto.Nombre)
                .ToList();
        }

    }
}

