using Libreria.LogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Libreria.LogicaNegocio.IRepositorios
{
    public interface IRepositorioOcular
    {
        IEnumerable<Ocular> FindAll();
    }
}
