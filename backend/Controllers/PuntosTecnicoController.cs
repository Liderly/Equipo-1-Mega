   
using Microsoft.AspNetCore.Mvc;
   
   
    [ApiController]
    [Route("api/[controller]")]
    public class PuntosTecnicoController : ControllerBase
    {
        private readonly ServicePuntosTecnico _servicio;

        public PuntosTecnicoController(ServicePuntosTecnico servicio)
        {
            _servicio = servicio;
        }

        /// <summary>
        ///     Devuelve los datos de un Técnico Instalador en específico por su numero de empleado.
        /// </summary>
        /// <param name="numTec"></param>
        /// <returns>Datos de bono de un técnico instalador</returns>
        [HttpGet("{numTec}")]
        public async Task<ActionResult<List<PuntosCuadrilla>>> ObtenerResultados(string numTec)
        {
            var resultados = await _servicio.EjecutarProcedimientoPuntosTecnicoAsync(numTec);
            if (resultados == null || !resultados.Any())
            {
                return NotFound(new { message = "No se encontro técnico instalador con número: " + numTec });
            }
            return Ok(resultados);
        }
    }