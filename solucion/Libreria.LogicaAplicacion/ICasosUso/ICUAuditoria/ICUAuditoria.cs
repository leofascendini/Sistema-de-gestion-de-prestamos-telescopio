using Libreria.DTOs.DataTransferObjects.DTOsAuditoria;
using Libreria.LogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Libreria.LogicaAplicacion.ICasosUso.ICUAuditoria
{
    public interface ICUAuditoria
    {
            List<DTOAuditoriaPrestamo> Obtener(int? coordinadorId);
            List<DTOAuditoriaPrestamo> ObtenerPorPrestamo(int prestamoId);
        }
    }

