using Libreria.DTOs.DataTransferObjects.DTOsEquipo;
using Libreria.LogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Libreria.LogicaAplicacion.ICasosUso.ICUEquipo
{
    public interface ICUGestionEquipo
    {
            void Alta(DTOGestionEquipo dto);
            void Delete(int id);
            
            void Edit(DTOGestionEquipo dto);
            IEnumerable<DTOGestionEquipo> ObtenerTodos();
            DTOGestionEquipo ObtenerPorId(int id);
    }
}
