using System;
using System.Collections.Generic;
using System.Text;

namespace Libreria.DTOs.DataTransferObjects.DTOsAuditoria
{
    public class DTOAuditoriaPrestamo
    {
        public int PrestamoId { get; set; }
        public DateTime Fecha { get; set; }
        public string UsuarioCoordinador { get; set; }
        public string Accion { get; set; }
        public string Observacion { get; set; }
    }
}
