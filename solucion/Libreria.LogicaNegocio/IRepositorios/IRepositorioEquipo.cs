using Libreria.LogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Libreria.LogicaNegocio.IRepositorios
{
    public interface IRepositorioEquipo
    {
        void Add(Equipo equipo);
        void Update(Equipo equipo);
        void Delete(int id);
        Equipo FindById(int id);
        IEnumerable<Equipo> FindAll();
    }
}
