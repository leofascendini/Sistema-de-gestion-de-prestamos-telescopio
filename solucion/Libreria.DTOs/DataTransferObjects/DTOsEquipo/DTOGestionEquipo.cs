using Libreria.LogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Libreria.DTOs.DataTransferObjects.DTOsEquipo
{
    public class DTOGestionEquipo
    {
        public int EquipoId { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public int CantidadDisponible { get; set; }

        public string TipoEquipo { get; set; }

        public TipoMontura? TipoMontura { get; set; }
        public double? CargaUtil { get; set; }
        public bool EsGoTo { get; set; }

        public double? Apertura { get; set; }
        public string? RelacionFocal { get; set; }
        public double? DistanciaFocal { get; set; }
        public double? Peso { get; set; }

        public double? Diametro { get; set; }
        public double? AnguloVision { get; set; }

        public TipoSensor? TipoSensor { get; set; }
        public string? Resolucion { get; set; }
        public double? TamañoPixel { get; set; }
    }
}
