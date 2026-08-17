using Libreria.DTOs.DataTransferObjects.DTOsAuditoria;
using Libreria.LogicaNegocio.Entidades;
using System.Collections.Generic;

namespace Libreria.DTOs.Mappers
{

    public static class AuditoriaMapper
    {
        public static DTOAuditoriaPrestamo ToDTO(Auditoria a)
        {
            return new DTOAuditoriaPrestamo
            {
                PrestamoId = a.PrestamoId,
                Fecha = a.Fecha,
                Accion = a.Accion,
                Observacion = a.Observacion,

                UsuarioCoordinador =
                    a.UsuarioCoordinador != null && a.UsuarioCoordinador.NombreCompleto != null
                        ? $"{a.UsuarioCoordinador.NombreCompleto.Nombre} {a.UsuarioCoordinador.NombreCompleto.Apellido}"
                        : "Sin usuario"
            };
        }

        public static List<DTOAuditoriaPrestamo> ToDTOList(List<Auditoria> lista)
        {
            if (lista == null)
                return new List<DTOAuditoriaPrestamo>();

            return lista.Select(ToDTO).ToList();
        }
    }
}
