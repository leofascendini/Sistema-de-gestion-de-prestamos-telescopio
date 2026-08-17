using Libreria.AccesoDatos;
using Libreria.LogicaNegocio.Entidades;
using Libreria.LogicaNegocio.IRepositorios;
using System;
using System.Collections.Generic;
using System.Text;

namespace Libreria.AccesoDatos.Repositorios
{
    public class RepositorioEquipo : IRepositorioEquipo
    {
        private ApplicationDbContext _context;

        public RepositorioEquipo(ApplicationDbContext context)
        {
            _context = context;
        }
        public void Add(Equipo equipo)
        {
            _context.Set<Equipo>().Add(equipo);
            _context.SaveChanges();
        }

        public void Update(Equipo equipo)
        {
            _context.Set<Equipo>().Update(equipo);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var equipo = _context.Set<Equipo>().Find(id);
            if (equipo != null)
            {
                _context.Set<Equipo>().Remove(equipo);
                _context.SaveChanges();
            }
        }

        public Equipo FindById(int id)
        {
            return _context.Set<Equipo>().Find(id);
        }

        public IEnumerable<Equipo> FindAll()
        {
            return _context.Set<Equipo>().ToList();
        }
    }
}
