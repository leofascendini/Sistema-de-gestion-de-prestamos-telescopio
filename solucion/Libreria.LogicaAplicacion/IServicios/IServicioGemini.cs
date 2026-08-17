using Libreria.DTOs.DataTransferObjects.DTOsObservacionAstro;
using Libreria.LogicaNegocio.Entidades;

namespace Libreria.LogicaAplicacion.IServicios
{
    public interface IServicioGemini
    {
        Task<DTOResultadoAltaObservacion> EvaluarObservacion(Prestamo prestamo, ObjetoCeleste objeto);
    }
}

