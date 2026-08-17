using Libreria.DTOs.DataTransferObjects.DTOsEquipo;
using System;
using System.Collections.Generic;
using System.Text;

namespace Libreria.LogicaAplicacion.ICasosUso.ICUEquipo
{
    public interface ICUEquipoDisponible
    {
        DTOEquipoDisponible Ejecutar(int id);
    }
}

