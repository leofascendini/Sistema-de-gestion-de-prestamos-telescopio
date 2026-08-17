using Libreria.AccesoDatos;
using Libreria.LogicaNegocio.Entidades;
using Libreria.LogicaNegocio.IRepositorios;
using System;
using System.Collections.Generic;
using System.Text;

namespace Libreria.AccesoDatos.Repositorios
{
    public class RepositorioCamara : IRepositorioCamara
    {
        private ApplicationDbContext _context;

        public RepositorioCamara(ApplicationDbContext context)
        {
            _context = context;
        }
        public IEnumerable<Camara> FindAll()
        {
            return _context.Camaras.ToList();
        }
    }
}
