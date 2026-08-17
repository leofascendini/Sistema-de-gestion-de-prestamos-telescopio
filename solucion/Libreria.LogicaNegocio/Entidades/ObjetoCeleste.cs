using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Libreria.LogicaNegocio.Entidades
{
    public class ObjetoCeleste
    {
        public int ObjetoCelesteId { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio")]
        public string nombre {  get; set; }

        [Required(ErrorMessage = "El tipo es obligatorio")]
        public TipoObjeto tipo { get; set; }

        [Required(ErrorMessage = "La magnitud aparente es obligatoria")]
        public double magnitudAparente { get; set; }
    }
}
