namespace ClienteWebApp.Models
{
    public class DevolucionPrestamoModel
    {
        public int PrestamoId { get; set; }
        public int UsuarioId { get; set; }
        public DateTime FechaDevolucion { get; set; }
        public string? Observacion { get; set; }
    }
}
