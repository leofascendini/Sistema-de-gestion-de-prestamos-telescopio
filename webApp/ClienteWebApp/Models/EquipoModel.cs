namespace ClienteWebApp.Models
{
    public class EquipoModel
    {
        public int EquipoId { get; set; }

        public string Marca { get; set; }

        public string Modelo { get; set; }

        public int CantidadDisponible { get; set; }

        public string TipoEquipo { get; set; }

        // Montura
        public string? TipoMontura { get; set; }
        public double? CargaUtil { get; set; }
        public bool EsGoTo { get; set; }

        // Telescopio
        public double? Apertura { get; set; }
        public string? RelacionFocal { get; set; }
        public double? DistanciaFocal { get; set; }
        public double? Peso { get; set; }

        // Ocular
        public double? Diametro { get; set; }
        public double? AnguloVision { get; set; }

        // Cámara
        public string? TipoSensor { get; set; }
        public string? Resolucion { get; set; }
        public double? TamañoPixel { get; set; }
    }
}
