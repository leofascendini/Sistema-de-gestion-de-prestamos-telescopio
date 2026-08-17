using System;
using System.Collections.Generic;
using System.Text;

namespace Libreria.DTOs.DataTransferObjects.DTOsUsuario
{
    public class DTOLoginUsuario
    {
        public string Email { get; set; }
        public string Contraseña { get; set; }
    }

    public class DTOLoginRespuesta
    {
        public string Token { get; set; }
    }
}
