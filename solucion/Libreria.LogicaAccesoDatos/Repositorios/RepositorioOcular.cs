using Libreria.AccesoDatos;
using Libreria.LogicaNegocio.Entidades;
using Libreria.LogicaNegocio.IRepositorios;
using System;
using System.Collections.Generic;
using System.Text;

namespace Libreria.AccesoDatos.Repositorios
{
    public class RepositorioOcular : IRepositorioOcular
    {
        private ApplicationDbContext _context;

        public RepositorioOcular(ApplicationDbContext context)
        {
            _context = context;
        }
        public IEnumerable<Ocular> FindAll()
        {
            return _context.Oculares.ToList();
        }
    }
}
