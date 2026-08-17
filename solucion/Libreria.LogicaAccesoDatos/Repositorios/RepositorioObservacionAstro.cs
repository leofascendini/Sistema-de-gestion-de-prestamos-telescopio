using Libreria.AccesoDatos;
using Libreria.LogicaNegocio.Entidades;
using Libreria.LogicaNegocio.IRepositorios;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Libreria.AccesoDatos.Repositorios
{
    public class RepositorioObservacionAstro : IRepositorioObservacionAstro
    {
        private ApplicationDbContext _context;

        public RepositorioObservacionAstro(ApplicationDbContext context)
        {
            _context = context;
        }
        public void Add(ObservacionAstro observacion)
        {
            _context.ObservacionAstros.Add(observacion);
            _context.SaveChanges();
        }
        public IEnumerable<ObjetoCeleste> ObtenerObjetosObservados()
        {
            return _context.ObservacionAstros
                .Include(o => o.ObjetoCeleste)
                .Select(o => o.ObjetoCeleste)
                .ToList();
        }
    }
}
