using Libreria.DTOs.DataTransferObjects.DTOsCamara;
using Libreria.DTOs.DataTransferObjects.DTOsMontura;
using Libreria.DTOs.DataTransferObjects.DTOsOcular;
using Libreria.DTOs.DataTransferObjects.DTOsTelescopio;
using Libreria.DTOs.DataTransferObjects.DTOsUsuario;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Libreria.DTOs.DataTransferObjects.DTOsPrestamo
{
    public class DTOAltaPrestamo
    {
        [Required(ErrorMessage = "El usuario es obligatorio")]
        public int UsuarioId { get; set; }

        [Required(ErrorMessage = "El telescopio es obligatorio")]
        public int TelescopioId { get; set; }

        [Required(ErrorMessage = "La montura es obligatoria")]
        public int MonturaId { get; set; }

        public int? CamaraId { get; set; }

        public int? OcularId { get; set; }
        public DateTime FechaFin { get; set; }
    }
    public class DTOPrestamoFormulario
    {
        public List<DTOUsuarioListado> Usuarios { get; set; }
        public List<DTOTelescopioListado> Telescopios { get; set; }
        public List<DTOMonturaListado> Monturas { get; set; }
        public List<DTOCamaraListado> Camaras { get; set; }
        public List<DTOOcularListado> Oculares { get; set; }
    }
}

