using Libreria.AccesoDatos;
using Libreria.LogicaNegocio.Entidades;
using Libreria.LogicaNegocio.IRepositorios;
using System;
using System.Collections.Generic;
using System.Text;

namespace Libreria.AccesoDatos.Repositorios
{
    public class RepositorioObjetoCeleste : IRepositorioObjetoCeleste
    {
        private ApplicationDbContext _context;

        public RepositorioObjetoCeleste(ApplicationDbContext context)
        {
            _context = context;
        }

        public ObjetoCeleste FindById(int id)
        {
            return _context.ObjetosCelestes.FirstOrDefault(o => o.ObjetoCelesteId == id);
        }
        public List<ObjetoCeleste> FindAll()
        {
            return _context.ObjetosCelestes.ToList();
        }
    }
}
