using Libreria.LogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Libreria.DTOs.DataTransferObjects.DTOsMontura
{
    public class DTOMonturaListado
    {
        public int EquipoId { get; set; }
        public string Nombre { get; set; }
        public TipoMontura tipoMontura { get; set; }
        public double cargaUtil {  get; set; }
    }
}
