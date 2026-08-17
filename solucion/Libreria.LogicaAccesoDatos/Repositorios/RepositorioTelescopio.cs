using Libreria.AccesoDatos;
using Libreria.LogicaNegocio.Entidades;
using Libreria.LogicaNegocio.IRepositorios;
using System;
using System.Collections.Generic;
using System.Text;

namespace Libreria.AccesoDatos.Repositorios
{
    public class RepositorioTelescopio : IRepositorioTelescopio
    {
        private ApplicationDbContext _context;

        public RepositorioTelescopio(ApplicationDbContext context)
        {
            _context = context;
        }
        public IEnumerable<Telescopio> FindAll()
        {
            return _context.Telescopios.ToList();
        }
    }
}
