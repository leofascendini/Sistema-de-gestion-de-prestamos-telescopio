using Libreria.LogicaNegocio.Entidades;
using Libreria.LogicaNegocio.IRepositorios;
using System;
using System.Collections.Generic;
using System.Text;

namespace Libreria.AccesoDatos.Repositorios
{
    public class RepositorioRol : IRepositorioRol
    {
        private ApplicationDbContext _context;

        public RepositorioRol(ApplicationDbContext context)
        {
            _context = context;

        }
        public int Add(Rol obj)
        {
            throw new NotImplementedException();
        }

        public List<Rol> FindAll()
        {
            return _context.Roles.ToList();
        }

        public Rol FindById(int id)
        {
            return _context.Roles.FirstOrDefault(r => r.RolId == id);
        }

        public Rol FindByName(string nombre)
        {
            return _context.Roles.Where(r => r.Nombre.Equals(nombre)).SingleOrDefault();
        }

        public void Remove(Rol obj)
        {
            throw new NotImplementedException();
        }

        public void Update(Rol obj)
        {
            throw new NotImplementedException();
        }
    }
}
