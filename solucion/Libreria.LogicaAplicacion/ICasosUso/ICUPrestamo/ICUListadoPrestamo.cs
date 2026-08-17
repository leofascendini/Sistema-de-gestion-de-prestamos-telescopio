using Libreria.DTOs.DataTransferObjects.DTOsPrestamo;
using System;
using System.Collections.Generic;
using System.Text;

namespace Libreria.LogicaAplicacion.ICasosUso.ICUPrestamo
{
    public interface ICUPrestamoListado
    {
        List<DTOPrestamoListado> ListarPrestamo(int UsuarioId);
    }
}
