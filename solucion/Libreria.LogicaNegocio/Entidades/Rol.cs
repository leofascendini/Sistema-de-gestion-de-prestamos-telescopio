using System;
using System.Collections.Generic;
using System.Text;

namespace Libreria.LogicaNegocio.Entidades
{
    public class Rol
    {
            public int RolId { get; set; }
            public string Nombre { get; set; }
            public List<Usuario> Usuarios { get; set; }
        
    }
}
