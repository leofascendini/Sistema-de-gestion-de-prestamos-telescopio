using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Libreria.DTOs.DataTransferObjects.DTOsPrestamo
{
    public class DTODevolucionPrestamo
    {
        public int PrestamoId { get; set; }
        public string? Observacion { get; set; }
        public DateTime FechaDevolucion { get; set; }
    }
}
