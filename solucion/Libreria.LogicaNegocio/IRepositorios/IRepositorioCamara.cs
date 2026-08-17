using Libreria.LogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Libreria.LogicaNegocio.IRepositorios
{
    public interface IRepositorioCamara
    {
        IEnumerable<Camara> FindAll();
    }
}
