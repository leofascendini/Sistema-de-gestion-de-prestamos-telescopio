using Libreria.LogicaNegocio.ValueObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Libreria.DTOs.DataTransferObjects.DTOsUsuario
{
    public  class DTOAltaUsuario
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El apellido es obligatorio")]
        public string Apellido { get; set; }
        public string Direccion { get; set; }

        [Required(ErrorMessage = "El telefono es obligatorio")]
        public int Telefono { get; set; }

        [Required(ErrorMessage = "El email es obligatorio")]
        [EmailAddress(ErrorMessage = "El email no tiene un formato valido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "El nombre de usuario es obligatorio")]
        public string NombreUsuario { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 8)]
        [RegularExpression(
    @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^a-zA-Z0-9]).{8,}$",
    ErrorMessage = "La contraseña debe tener al menos 8 caracteres, una mayuscula, una minuscula, un numero y un caracter especial.")]
        public string Contraseña { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Debe seleccionar un rol")]
        public int RolId { get; set; }
    }
}
