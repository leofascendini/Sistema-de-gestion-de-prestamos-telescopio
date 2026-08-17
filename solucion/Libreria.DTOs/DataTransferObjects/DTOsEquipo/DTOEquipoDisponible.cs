using System;
using System.Collections.Generic;
using System.Text;

namespace Libreria.DTOs.DataTransferObjects.DTOsEquipo
{
    public class DTOEquipoDisponible
    {
        public int EquipoId { get; set; }
        public string Nombre { get; set; }
        public int CantidadDisponible { get; set; }
        public bool Disponible { get; set; }
    }
}
