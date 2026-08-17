using Libreria.DTOs.DataTransferObjects.DTOsPrestamo;
using System;
using System.Collections.Generic;
using System.Text;

namespace Libreria.LogicaAplicacion.ICasosUso.ICUPrestamo
{
    public interface ICUPrestamoListadoEntreFechas
    {
        List<DTOPrestamoListado> ListarPrestamoEntreFechas(int usuarioId, int mes, int anio);
    }
}
