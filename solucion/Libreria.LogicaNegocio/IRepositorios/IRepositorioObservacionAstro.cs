using Libreria.LogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Libreria.LogicaNegocio.IRepositorios
{
    public interface IRepositorioObservacionAstro
    {
        void Add(ObservacionAstro observacion);
        IEnumerable<ObjetoCeleste> ObtenerObjetosObservados();
    }
}
