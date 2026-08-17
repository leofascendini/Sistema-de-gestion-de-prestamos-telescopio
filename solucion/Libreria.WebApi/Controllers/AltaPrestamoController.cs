using Libreria.DTOs.DataTransferObjects.DTOsPrestamo;
using Libreria.LogicaAplicacion.ICasosUso.ICUPrestamo;
using Libreria.LogicaNegocio.CustomExceptions.EquipoExceptions;
using Libreria.LogicaNegocio.CustomExceptions.GenericasExceptions;
using Libreria.LogicaNegocio.CustomExceptions.PrestamoExceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Libreria.WebApi.Controllers
{
    [Authorize(Roles = "Coordinador")]
    [Route("api/[controller]")]
    [ApiController]
    public class AltaPrestamoController : ControllerBase
    {
        private ICUAltaPrestamo _cuAltaPrestamo;
        private ICUPrestamoListado _cuPrestamoListado;
        private ICUCargarDatosPrestamo _cuCargarDatosPrestamo;

        public AltaPrestamoController(ICUAltaPrestamo cuAltaPrestamo, ICUPrestamoListado cuPrestamoListado, ICUCargarDatosPrestamo cuCargarDatosPrestamo)
        {
            _cuAltaPrestamo = cuAltaPrestamo;
            _cuPrestamoListado = cuPrestamoListado;
            _cuCargarDatosPrestamo = cuCargarDatosPrestamo;
        }


        [HttpPost]
        public IActionResult Create(DTOAltaPrestamo dto)
        {
            try 
            {
                _cuAltaPrestamo.AltaPrestamo(dto);
                return StatusCode(200, "Alta de prestamo correctamente");
            }
            catch (DatoVacioONuloException e)
            {
                return StatusCode(400, e.Message);
            }
            catch (EquipoNoDisponibleException e) 
            {
                return StatusCode(400, e.Message);
            }
            catch (NoEsCompatibleExceptions e)
            {
                return StatusCode(400, e.Message);
            }
            catch (PesoMayorACargaExceptions e)
            {
                return StatusCode(400, e.Message);
            }            
            catch
            {
                return StatusCode(500, "Error de servidor");
            }
        }
    }
}
