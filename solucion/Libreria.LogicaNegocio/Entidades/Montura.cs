using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Libreria.LogicaNegocio.Entidades
{
    public class Montura : Equipo
    {
        [Required(ErrorMessage = "El tipo de montura es obligatorio")]
        public TipoMontura tipoMontura {  get; set; }

        [Range(0.1, double.MaxValue, ErrorMessage = "La carga util debe ser mayor a 0")]
        public double cargaUtil {  get; set; }
        public bool esGoTo {  get; set; }

    }
}
