using Libreria.LogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Libreria.LogicaNegocio.IRepositorios
{
    public interface IRepositorioAuditoria
    {
            void Add(Auditoria auditoria);
            List<Auditoria> GetAll();

            List<Auditoria> GetByCoordinador(int coordinadorId);

            List<Auditoria> GetByPrestamo(int prestamoId);
    }
}
