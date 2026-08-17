using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Libreria.LogicaNegocio.Entidades
{
    public class Telescopio : Equipo
    {
        [Range(1, double.MaxValue, ErrorMessage = "La apertura debe ser mayor a 0")]
        public double apertura {  get; set; }

        [Required(ErrorMessage = "La relacion focal es obligatoria")]
        public string relacionFocal { get; set; }

        [Range(1, double.MaxValue, ErrorMessage = "La distancia focal debe ser mayor a 0")]
        public double distanciaFocal { get; set; }

        [Range(0.1, double.MaxValue, ErrorMessage = "El peso debe ser mayor a 0")]
        public double peso { get; set; }
    }
}
