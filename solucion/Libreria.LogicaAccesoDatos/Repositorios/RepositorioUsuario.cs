using Libreria.AccesoDatos;
using Libreria.LogicaNegocio.Entidades;
using Libreria.LogicaNegocio.IRepositorios;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Libreria.AccesoDatos.Repositorios
{
    public class RepositorioUsuario : IRepositorioUsuario
    {

        private ApplicationDbContext _context;

        public RepositorioUsuario(ApplicationDbContext context)
        {
            _context = context;

        }
        public int Add(Usuario obj)
        {
            _context.Usuarios.Add(obj);
            _context.SaveChanges();
            return obj.UsuarioId;
        }

        public List<Usuario> FindAll()
        {
            return _context.Usuarios.ToList();
        }
        public Usuario FindByEmail(string email)
        {
            return _context.Usuarios.Include(u => u.Rol).FirstOrDefault(u => u.Email == email);
        }
        public Usuario FindById(int id)
        {
            Usuario buscado = _context.Usuarios.Where(p => p.UsuarioId.Equals(id)).SingleOrDefault();
            return buscado;
        }

        public void Remove(Usuario obj)
        {
            _context.Usuarios.Remove(obj);
            _context.SaveChanges();
        }

        public void Update(Usuario obj)
        {
            _context.Usuarios.Update(obj);
            _context.SaveChanges();
        }
    }
}
