using Libreria.DTOs.DataTransferObjects.DTOsPrestamo;
using System;
using System.Collections.Generic;
using System.Text;

namespace Libreria.LogicaAplicacion.ICasosUso.ICUPrestamo
{
    public interface ICUListadoSociosPorTelescopio
    {
        List<DTOTelescopioPorSocio> ListarSociosPorTelescopio(int telescopioId);
    }
}
