namespace ClienteWebApp.Models
{
    public class AltaPrestamoModel
    {
        public int UsuarioId { get; set; }
        public int TelescopioId { get; set; }
        public int MonturaId { get; set; }
        public int? CamaraId { get; set; }
        public int? OcularId { get; set; }
        public DateTime FechaFin { get; set; }
    }
}
