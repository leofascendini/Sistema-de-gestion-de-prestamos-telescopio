using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Libreria.LogicaNegocio.Entidades
{
    public class ObservacionAstro
    {
        public int ObservacionAstroId { get; set; }

        [Required(ErrorMessage = "La fecha es obligatoria")]
        public DateTime fechaObservacion {  get; set; }

        [Required(ErrorMessage = "El resultado de la IA es obligatorio")]
        public ResultadoObservacion ResultadoIA { get; set; }

        [MaxLength(300, ErrorMessage = "El detalle no puede superar los 300 caracteres")]
        public string ExplicacionIA { get; set; }

        public int PrestamoId { get; set; }
        public Prestamo Prestamo { get; set; }
        public int ObjetoCelesteId { get; set; }
        public ObjetoCeleste ObjetoCeleste { get; set; }
    }
}
