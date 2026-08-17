namespace ClienteWebApp.Models
{
    public class ListadoPrestamoModel
    {
        public int PrestamoId { get; set; }
        public string Usuario { get; set; }
        public string Telescopio { get; set; }
        public string Montura { get; set; }
        public string Camara { get; set; }
        public string Ocular { get; set; }
        public int ObjetoCelesteId { get; set; }

        public List<ObjetoCelesteModel> ObjetosCelestes { get; set; } = new ();
    }
}
