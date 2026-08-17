using Libreria.DTOs.DataTransferObjects.DTOsPrestamo;
using Libreria.LogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Libreria.LogicaAplicacion.ICasosUso.ICUPrestamo
{
    public interface ICUPrestamosVigentes
    {
            List<DTOPrestamoListado> ListarPrestamosVigentes(int usuarioId);
    }
}
