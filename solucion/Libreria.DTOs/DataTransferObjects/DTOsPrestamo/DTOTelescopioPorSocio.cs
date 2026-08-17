using System;
using System.Collections.Generic;
using System.Text;

namespace Libreria.DTOs.DataTransferObjects.DTOsPrestamo
{
    public class DTOTelescopioPorSocio
    {
        public int UsuarioId { get; set; }
        public string NombreCompleto { get; set; }
        public string Email { get; set; }
        public string Telescopio { get; set; }
    }
}
