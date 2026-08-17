namespace ClienteWebApp.Models
{
    public class ObservacionModel
    {
        public int ObjetoCelesteId { get; set; }
        public int PrestamoId { get; set; }
        public string? Descripcion { get; set; }
        public DateTime Fecha { get; set; }
    }
}
