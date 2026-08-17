using ClienteWebApp.Models.ClienteWebApp.Models;

namespace ClienteWebApp.Models
{
    public class TelescopioPorSocioVistaModel
    {
        public int TelescopioId { get; set; }
        public List<TelescopioListadoModel> Telescopios { get; set; }
            = new();
        public List<TelescopioPorSocioModel> Socios { get; set; }
            = new();
    }
}
