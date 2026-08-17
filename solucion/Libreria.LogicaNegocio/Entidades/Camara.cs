using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Libreria.LogicaNegocio.Entidades
{
    public class Camara : Equipo
    {
        [Required(ErrorMessage = "El tipo de sensor es obligatorio")]
        public TipoSensor tipoSensor {  get; set; }

        [Required(ErrorMessage = "La resolucion es obligatoria")]
        public string resolucion {  get; set; }

        [Range(0.1, double.MaxValue, ErrorMessage = "El tamaño de pixel debe ser mayor a 0")]
        public double tamañoPixel {  get; set; }
    }
}
