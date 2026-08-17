using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Libreria.LogicaNegocio.Entidades
{
    public class Equipo
    {
        public int EquipoId {  get; set; }

        [Required(ErrorMessage = "La marca es obligatoria")]
        public string marca { get; set; }

        [Required(ErrorMessage = "El modelo es obligatorio")]
        public string modelo { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "La cantidad disponible no puede ser negativa")]
        public int cantidadDisponible { get; set; }
    }
}
