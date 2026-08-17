using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Libreria.LogicaNegocio.Entidades
{
    public class Prestamo
    {
        public int PrestamoId { get; set; }

        [Required(ErrorMessage = "La fecha de inicio es obligatoria")]
        public DateTime fechaInicio {  get; set; }

        [Required(ErrorMessage = "La fecha de fin es obligatoria")]
        public DateTime fechaFin {  get; set; }

        [Required(ErrorMessage = "El estado es obligatorio")]
        public EstadoPrestamo estado {  get; set; }

        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }

        public int TelescopioId { get; set; }
        public Telescopio Telescopio { get; set; }

        public int MonturaId { get; set; }
        public Montura Montura { get; set; }

        public int? CamaraId { get; set; }
        public Camara Camara { get; set; }

        public int? OcularId { get; set; }
        public Ocular Ocular { get; set; }
    }
}
