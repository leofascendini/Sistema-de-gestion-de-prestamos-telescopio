using Libreria.LogicaNegocio.Entidades;
using Libreria.LogicaNegocio.IRepositorios;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Libreria.AccesoDatos.Repositorios
{
    
        public class RepositorioAuditoria : IRepositorioAuditoria
        {
            private ApplicationDbContext _context;

            public RepositorioAuditoria(ApplicationDbContext context)
            {
                _context = context;
            }
            public void Add(Auditoria auditoria)
        {
            _context.Set<Auditoria>().Add(auditoria);
            _context.SaveChanges();
        }
        public List<Auditoria> GetAll()
        {
            return _context.Set<Auditoria>()
                .Include(a => a.UsuarioCoordinador)
                .Include(a => a.Prestamo)
                .OrderByDescending(a => a.Fecha)
                .ToList();
        }
        public List<Auditoria> GetByCoordinador(int coordinadorId)
        {
            return _context.Set<Auditoria>()
                .Include(a => a.UsuarioCoordinador)
                .Include(a => a.Prestamo)
                .Where(a => a.UsuarioCoordinadorId == coordinadorId)
                .OrderByDescending(a => a.Fecha)
                .ToList();
        }
        public List<Auditoria> GetByPrestamo(int prestamoId)
        {
            return _context.Set<Auditoria>()
                .Include(a => a.UsuarioCoordinador)
                .Where(a => a.PrestamoId == prestamoId)
                .OrderByDescending(a => a.Fecha)
                .ToList();
        }
    }
}
