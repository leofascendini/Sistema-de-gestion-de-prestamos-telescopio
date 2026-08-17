namespace ClienteWebApp.Models
{
    public class AuditoriaModel
    {
        public int PrestamoId { get; set; }
        public DateTime Fecha { get; set; }
        public string UsuarioCoordinador { get; set; }
        public string Accion { get; set; }

        public string Observacion { get; set; }

    }
}
