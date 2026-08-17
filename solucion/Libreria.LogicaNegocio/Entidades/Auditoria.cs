using System;
using System.Collections.Generic;
using System.Text;

namespace Libreria.LogicaNegocio.Entidades
{
    public class Auditoria
    {
        public int AuditoriaPrestamoId { get; set; }

        public string? Accion { get; set; }

        public DateTime Fecha { get; set; }

        public int UsuarioCoordinadorId { get; set; }

        public Usuario? UsuarioCoordinador { get; set; }

        public int PrestamoId { get; set; }

        public Prestamo? Prestamo { get; set; }
        public string? Observacion { get; set; }
    }
}
