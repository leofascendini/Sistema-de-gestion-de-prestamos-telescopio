//using Libreria.LogicaNegocio.Entidades;
//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace Libreria.LogicaNegocio.IRepositorios

using Libreria.LogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Libreria.LogicaNegocio.IRepositorios
{
    public interface IRepositorioRol : IRepositorio<Rol>
    {
            Rol FindByName(string nombre);
    }
}
