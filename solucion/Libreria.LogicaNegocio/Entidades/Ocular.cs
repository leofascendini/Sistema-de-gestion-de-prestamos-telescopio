using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Libreria.LogicaNegocio.Entidades
{
    public class Ocular : Equipo
    {
        [Range(1, double.MaxValue, ErrorMessage = "El diametro debe ser mayor a 0")]
        public double diametro {  get; set; }

        [Range(1, 180, ErrorMessage = "El angulo de vision debe estar entre 1 y 180 grados")]
        public double anguloVision { get; set; }
    }
}
