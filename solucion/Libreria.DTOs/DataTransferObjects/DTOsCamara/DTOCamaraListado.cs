using Libreria.LogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Libreria.DTOs.DataTransferObjects.DTOsCamara
{
    public class DTOCamaraListado
    {
        public int EquipoId { get; set; }
        public string Nombre { get; set; }
        public TipoSensor TipoSensor { get; set; }
        public string Resolucion { get; set; }
        public double TamañoPixel {  get; set; }

    }
}
