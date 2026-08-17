using Libreria.AccesoDatos;
using Libreria.LogicaNegocio.Entidades;
using Libreria.LogicaNegocio.IRepositorios;
using System;
using System.Collections.Generic;
using System.Text;

namespace Libreria.AccesoDatos.Repositorios
{
    public class RepositorioMontura : IRepositorioMontura
    {
        private ApplicationDbContext _context;

        public RepositorioMontura(ApplicationDbContext context)
        {
            _context = context;

        }
        public IEnumerable<Montura> FindAll()
        {
            return _context.Monturas.ToList();
        }
    }
}
